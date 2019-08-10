using System;
using System.Collections.Generic;
using NUnit.Framework;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.ViewModels;

namespace ZbW.Testing.Dms.IntegrationTests.ViewModelTests
{
    [TestFixture]
    internal class SearchViewModelTests
    {
        [Test]
        public void SearchViewModel_GetSet_FilteredMetadaItems()
        {
            // Arrange
            var searchViewModel = new SearchViewModel
            {
                FilteredMetadataItems = new List<MetadataItem> {new MetadataItem(DateTime.MinValue, "Test")}
            };

            // Act
            var filteredCount = searchViewModel.FilteredMetadataItems.Count;

            // Assert
            Assert.That(filteredCount, Is.EqualTo(1));
        }
        [Test]
        public void SerachViewModel_GetSet_SelectedMetadataItem()
        {
            // Arrange
            var searchViewModel = new SearchViewModel {SelectedMetadataItem = new MetadataItem(DateTime.MinValue, "Test")};

            // Act
            var valutaDatum = searchViewModel.SelectedMetadataItem.ValutaDatum;
            var type = searchViewModel.SelectedMetadataItem.Type;

            // Assert
            Assert.That(valutaDatum, Is.EqualTo(DateTime.MinValue));
            Assert.That(type, Is.EqualTo("Test"));
        }
        [Test]
        public void SearchViewModel_OpenFile_CanExecute()
        {
            // Arrange
            var searchViewModel = new SearchViewModel {SelectedMetadataItem = new MetadataItem(DateTime.MinValue, "Test")};

            // Act
            var ableToOpen = searchViewModel.CmdOeffnen.CanExecute();

            // Assert
            Assert.That(ableToOpen, Is.True);
        }
    }
}
