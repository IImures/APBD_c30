using System.Text.Json;
using EF_ZAD.Exceptions;

namespace EF_ZAD.Middlewares;

public class ExceptionHandler
{
    private readonly RequestDelegate _next;
    
    public ExceptionHandler(RequestDelegate next)
    {
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = 404;
            context.Response.ContentType = "application/json";
            string jsonResponse = JsonSerializer.Serialize(new
            {
                Message = ex.Message,
                Time = DateTime.Now
            });
            
            
            await context.Response.WriteAsync(jsonResponse);
        
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = 500;
            context.Response.ContentType = "application/json";
            string jsonResponse = JsonSerializer.Serialize(new
            {
                Message = ex.Message,
                Time = DateTime.Now
            });
            
            
            await context.Response.WriteAsync(jsonResponse);
        }
    }
}