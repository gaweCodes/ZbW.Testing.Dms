using System;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.UnitTests.ViewModelsTests
{
    [TestFixture]
    internal class DocumentDetailViewModelTests
    {
        private const string Username = "Gabriel";
        private readonly DateTime _testDateTime = DateTime.Now;
        [Test]
        public void DocumentDetail_IsAbleToSave_AbleToSave()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null);

            // Act
            var ableToSave = documentDetailViewModel.CmdSpeichern.CanExecute();

            // Assert
            Assert.That(ableToSave, Is.True);
        }
        [Test]
        public void DocumentDetail_IsAbleToSearch_AbleToSearch()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null);

            // Act
            var ableToSearch = documentDetailViewModel.CmdDurchsuchen.CanExecute();

            // Assert
            Assert.That(ableToSearch, Is.True);
        }
        [Test]
        public void DocumentDetail_IsValidUsername_UsernameIsValid()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null);

            // Act
            var username = documentDetailViewModel.Benutzer;

            // Assert
            Assert.That(username, Is.EqualTo(Username));
        }
        [Test]
        public void DocumentDetail_IsRemoveFileEnabled_RemoveFileIsEnabled()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null);

            // Act
            documentDetailViewModel.IsRemoveFileEnabled = true;
            var ableToRemoveFile = documentDetailViewModel.IsRemoveFileEnabled;

            // Assert
            Assert.That(ableToRemoveFile, Is.True);
        }
        [Test]
        public void DocumentDetail_IsTypItemSelected_TypeItemUsername()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null);
            documentDetailViewModel.SelectedTypItem = Username;

            // Act
            var typeItem = documentDetailViewModel.SelectedTypItem;

            // Assert
            Assert.That(typeItem, Is.EqualTo(Username));
        }
        [Test]
        public void DocumentDetail_GetBezeichnung_IsUsername()
        {
            // Arrange
            var documentDetailViewModel = new DocumentDetailViewModel(Username, null);
            documentDetailViewModel.Bezeichnung = Username;

            // Act
            var result = documentDetailViewModel.Bezeichnung;

            // Arrange
            Assert.That(result, Is.EqualTo(Username));
        }
        [Test]
        public void GetStichwoerter_Return_ValidUser()
        {
            var sut = new DocumentDetailViewModel(ValidUser, null);
            sut.Stichwoerter = ValidUser;

            var result = sut.Stichwoerter;

            Assert.That(result, Is.EqualTo(ValidUser));
        }

        [Test]
        public void ValutaDatum_Get_TestDateTime()
        {
            var sut = new DocumentDetailViewModel(ValidUser, null);
            sut.ValutaDatum = _testDateTime;

            var result = sut.ValutaDatum;

            Assert.That(result, Is.EqualTo(_testDateTime));
        }
    }
}
