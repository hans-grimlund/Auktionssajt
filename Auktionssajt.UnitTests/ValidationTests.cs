using Auktionssajt.Core.Services;
using Auktionssajt.Domain.Models;

namespace Auktionssajt.UnitTests;

[TestClass]
public class ValidationTests
{
    [TestMethod]
    public void ValidatePassword_PasswordNotNull_ReturnsOk()
    {
        // Arrange
        var validationService = new ValidationService();

        // Act
        var result = validationService.ValidatePassword("stringNotEmpty");

        // Assert
        Assert.AreEqual(Status.Ok, result);

    }

    [TestMethod]
    public void ValidatePassword_PasswordIsEmpty_ReturnsInvalid()
    {
        var validationService = new ValidationService();

        var result = validationService.ValidatePassword(string.Empty);

        Assert.AreEqual(Status.Invalid, result);
    }

    [TestMethod]
    public void ValidateUser_UsernameIsEmptyPasswordIsNot_ReturnsInvalid()
    {
        var validationService = new ValidationService();

        var result = validationService.ValidateUser(new("", "stringNotEmpty"));
        
        Assert.AreEqual(Status.Invalid, result);
    }

    [TestMethod]
    public void ValidateUser_PasswordIsEmptyUsernameIsNot_ReturnsInvalid()
    {
        var validationService = new ValidationService();

        var result = validationService.ValidateUser(new("stringNotEmpty", ""));
        
        Assert.AreEqual(Status.Invalid, result);

    }

    [TestMethod]
    public void ValidateUser_PasswordAndUsernameIsEmpty_ReturnsInvalid()
    {
        var validationService = new ValidationService();

        var result = validationService.ValidateUser(new("", ""));
        
        Assert.AreEqual(Status.Invalid, result);
    }

    [TestMethod]
    public void ValidateUser_PasswordAndUsernameIsNotEmpty_ReturnsOk()
    {
        var validationService = new ValidationService();

        var result = validationService.ValidateUser(new("stringNotEmpty", "stringNotEmpty"));
        
        Assert.AreEqual(Status.Ok, result);
    }
    [TestMethod]
    public void ValidateAuction_NotEmpty_ReturnsOk()
    {
        var validationService = new ValidationService();

        var result = validationService.ValidateAuction(new NewAuctionModel("stringNotEmpty", "stringNotEmpty", 10));

        Assert.AreEqual(Status.Ok, result);
    }
}