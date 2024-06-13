using System.Data.Entity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JWT.Context;
using JWT.Entities;
using JWT.Exceptions;
using JWT.RequestModels;
using JWT.ResponseModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace JWT.Services;

public class AuthService : IAuthService
{

    private readonly ApplicationContext _appContext;
    private readonly IConfiguration _configuration;
    
    public AuthService(ApplicationContext appContext, IConfiguration configuration)
    {
        _appContext = appContext;
        _configuration = configuration;
    }
    
    public async Task RegisterUser(RegisterRequest request)
    {
        var user = await _appContext.Users
            .FirstOrDefaultAsync(u => u.Name == request.Name);
        
        if (user != null)
        {
            throw new UserExitsException("User with this name already exists", 401);
        }
        
        User userToSave = new()
        {
            Name = request.Name,
            
        };
        
        PasswordHasher<User> passwordHasher = new();
        var hashedPassword = passwordHasher.HashPassword(userToSave, request.Password);
        
        userToSave.Password = hashedPassword;
        
        await _appContext.Users.AddAsync(userToSave);
        await _appContext.SaveChangesAsync();
    }

    public async Task<LoginResponse> LoginUser(LoginRequest request)
    {
        User? user =  await _appContext.Users
            .FirstOrDefaultAsync(u => u.Name == request.Name);
        
        if(user == null)
        {
            throw new NotFoundException("User with this name does not exists", 404);
        }
        if(!new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, request.Password).Equals(PasswordVerificationResult.Success))
        {
            throw new BadCredentialsException("Invalid password", 400);
        }
        
        return new LoginResponse
        {
            Token = GenerateJwtToken(user),
            RefreshToken = GenerateRefreshToken(user)
        };
    }

    public async Task<LoginResponse> RefreshToken(RefreshTokenRequest request)
    {
        if (!ValidateRefreshToken(request))
        {
            throw new UnauthorizedAccessException("Invalid refresh token");
        }
        
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(request.RefreshToken);
        
        string name = token.Claims.First(claim => claim.Type == ClaimTypes.Name).Value;
        
        User? user = await  _appContext.Users
            .FirstOrDefaultAsync(u => u.Name == name);
        
        return new LoginResponse
        {
            Token = GenerateJwtToken(user),
            RefreshToken = GenerateRefreshToken(user)
        };
    }


    public bool ValidateRefreshToken(RefreshTokenRequest request)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        try
        {
            tokenHandler.ValidateToken(request.RefreshToken, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _configuration["JWT:RefIssuer"],
                ValidAudience = _configuration["JWT:RefAudience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:RefKey"]!))
            }, out _);
            return true;
        }
        catch
        {
            return false;
        }
    }

    public string GenerateJwtToken(User user)
    {
        Claim[] userClaims = new[]
        {
            new Claim(ClaimTypes.Name, user.Name),
        };
        
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
        
        JwtSecurityToken token = new(
            _configuration["JWT:Issuer"],
            _configuration["JWT:Audience"],
            userClaims,
            expires: DateTime.Now.AddMinutes(15),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
    public string GenerateRefreshToken(User user)
    {
        Claim[] userClaims = new[]
        {
            new Claim(ClaimTypes.Name, user.Name),
        };
        
        SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_configuration["JWT:RefKey"]!));
        SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
        
        JwtSecurityToken token = new(
            _configuration["JWT:RefIssuer"],
            _configuration["JWT:RefAudience"],
            userClaims,
            expires: DateTime.Now.AddDays(3),
            signingCredentials: credentials
        );
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
    
}

public interface IAuthService
{
 
    public Task RegisterUser(RegisterRequest request);
    
    public Task<LoginResponse> LoginUser(LoginRequest request);
    
    public Task<LoginResponse> RefreshToken(RefreshTokenRequest request);
    
}