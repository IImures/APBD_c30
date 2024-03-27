using System;
using JetBrains.Annotations;
using Xunit;

namespace LegacyApp.Tests;

[TestSubject(typeof(UserService))]
public class UserServiceTest
{

    [Fact]
    public void AddUser_Should_Return_False_If_FirtsName_Is_Empty()
    {
        // Arrange - przygotowanie zależności do testu
        var userService = new UserService();
        // Act - wywolanie testowanej funcjalności
        var result = userService.AddUser("", "Doe", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        // Assert - sprawdzenie wyniku
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_If_LastName_Is_Empty()
    {
        // Arrange - przygotowanie zależności do testu
        var userService = new UserService();
        // Act - wywolanie testowanej funcjalności
        var result = userService.AddUser("John", "", "johndoe@gmail.com", DateTime.Parse("1982-03-21"), 1);
        // Assert - sprawdzenie wyniku
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_If_Email_Invalid()
    {
        // Arrange - przygotowanie zależności do testu
        var userService = new UserService();
        // Act - wywolanie testowanej funcjalności
        var result = userService.AddUser("John", "Doe", "johndoegmailcom", DateTime.Parse("1982-03-21"), 1);
        // Assert - sprawdzenie wyniku
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_If_Age_Less_Than_21()
    {
        var userService = new UserService();
        
        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("2006-03-21"), 1);
        
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Throw_ArgumentException_When_Client_Doesnt_Exists()
    {
        var userService = new UserService();
        
        Assert.Throws<ArgumentException>(() =>
        {
            userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1900-03-21"), 100);
        });
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Client_Is_Very_Important()
    {
        var userService = new UserService();

        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1900-03-21"), 2);

        Assert.True(result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Client_Is_Important()
    {
        var userService = new UserService();

        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1900-03-21"), 3);

        Assert.True(result);
    }

    [Fact]
    public void AddUser_Should_Return_False_When_Client_Has_CreditLimit_And_CreditLimit_Less_Then_500()
    {
        var userService = new UserService();

        var result = userService.AddUser("John", "Kowalski", "johndoe@gmail.com", DateTime.Parse("1900-03-21"), 1);
        
        Assert.False(result);
    }

    [Fact]
    public void AddUser_Should_Return_True_When_Client_Has_CreditLimit_And_CreditLimit_More_Then_500()
    {
        var userService = new UserService();

        var result = userService.AddUser("John", "Doe", "johndoe@gmail.com", DateTime.Parse("1900-03-21"), 4);

        Assert.True(result);
    }
}