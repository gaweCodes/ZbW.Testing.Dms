using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Prism.Commands;
using Prism.Mvvm;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Repositories;
using ZbW.Testing.Dms.Client.Services;

[assembly: InternalsVisibleTo("ZbW.Testing.Dms.UnitTests")]
[assembly: InternalsVisibleTo("ZbW.Testing.Dms.IntegrationTests")]
namespace ZbW.Testing.Dms.Client.ViewModels
{
    internal class SearchViewModel : BindableBase
    {
        private List<MetadataItem> _filteredMetadataItems;
        private MetadataItem _selectedMetadataItem;
        private string _selectedTypItem;
        private string _suchbegriff;
        private List<string> _typItems;
        private readonly DocumentService _documentService;
        public SearchViewModel()
        {
            TypItems = ComboBoxItems.Typ;
            CmdSuchen = new DelegateCommand(OnCmdSuchen);
            CmdReset = new DelegateCommand(OnCmdReset);
            CmdOeffnen = new DelegateCommand(OnCmdOeffnen, OnCanCmdOeffnen);
            _documentService = new DocumentService();
            FilteredMetadataItems = _documentService.GetAllMetadataItems();
        }
        public DelegateCommand CmdOeffnen { get; }
        public DelegateCommand CmdSuchen { get; }
        public DelegateCommand CmdReset { get; }
        public string Suchbegriff
        {
            get => _suchbegriff;
            set => SetProperty(ref _suchbegriff, value);
        }
        public List<string> TypItems
        {
            get => _typItems;
            set => SetProperty(ref _typItems, value);
        }
        public string SelectedTypItem
        {
            get => _selectedTypItem;
            set => SetProperty(ref _selectedTypItem, value);
        }
        public List<MetadataItem> FilteredMetadataItems
        {
            get => _filteredMetadataItems;
            set => SetProperty(ref _filteredMetadataItems, value);
        }
        public MetadataItem SelectedMetadataItem
        {
            get => _selectedMetadataItem;
            set
            {
                if (SetProperty(ref _selectedMetadataItem, value)) CmdOeffnen.RaiseCanExecuteChanged();
            }
        }
        private bool OnCanCmdOeffnen() => SelectedMetadataItem != null;
        private void OnCmdOeffnen() => _documentService.OpenFile(SelectedMetadataItem);
        private void OnCmdSuchen() => FilteredMetadataItems = _documentService.FilterMetadataItems(SelectedTypItem, Suchbegriff);
        private void OnCmdReset()
        {
            FilteredMetadataItems = _documentService.MetadataItems;
            Suchbegriff = string.Empty;
            SelectedTypItem = null;
        }
    }
}