using NUnit.Framework;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.UnitTests.ViewModelsTests
{
    [TestFixture]
    internal class LoginViewModelTests
    {
        private const string Username = "gabriel";
        private readonly string _invalidUsername = string.Empty;
        [Test]
        public void Login_HasUsername_IsTrue()
        {
            // Arrange
            var loginViewModel = new LoginViewModel(null);

            // Act
            loginViewModel.Benutzername = Username;
            var ableToLogin = loginViewModel.CmdLogin.CanExecute();

            // Assert
            Assert.That(ableToLogin, Is.True);
        }
        [Test]
        public void Login_NoUsername_IsFals()
        {
            // Arrange
            var loginViewModel = new LoginViewModel(null);

            // Act
            loginViewModel.Benutzername = _invalidUsername;
            var ableToLogin = loginViewModel.CmdLogin.CanExecute();

            // Assert
            Assert.That(ableToLogin, Is.False);
        }
    }
}
