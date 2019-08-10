using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Windows;
using Microsoft.Win32;
using Prism.Commands;
using Prism.Mvvm;
using ZbW.Testing.Dms.Client.Model;
using ZbW.Testing.Dms.Client.Repositories;
using ZbW.Testing.Dms.Client.Services;
using static System.String;

[assembly: InternalsVisibleTo("ZbW.Testing.Dms.UnitTests")]
[assembly: InternalsVisibleTo("ZbW.Testing.Dms.IntegrationTests")]
namespace ZbW.Testing.Dms.Client.ViewModels
{
    internal class DocumentDetailViewModel : BindableBase
    {
        private readonly Action _navigateBack;
        private string _benutzer;
        private string _bezeichnung;
        private DateTime _erfassungsdatum;
        private string _filePath;
        private bool _isRemoveFileEnabled;
        private string _selectedTypItem;
        private string _stichwoerter;
        private List<string> _typItems;
        private DateTime? _valutaDatum;
        private readonly DocumentService _documentService;
        public DocumentDetailViewModel(string benutzer, Action navigateBack)
        {
            _navigateBack = navigateBack;
            Benutzer = benutzer;
            Erfassungsdatum = DateTime.Now;
            TypItems = ComboBoxItems.Typ;
            _documentService = new DocumentService();
            CmdDurchsuchen = new DelegateCommand(OnCmdDurchsuchen);
            CmdSpeichern = new DelegateCommand(OnCmdSpeichern);
        }
        public string Stichwoerter
        {
            get => _stichwoerter;
            set => SetProperty(ref _stichwoerter, value);
        }
        public string Bezeichnung
        {
            get => _bezeichnung;
            set => SetProperty(ref _bezeichnung, value);
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
        public DateTime Erfassungsdatum
        {
            get => _erfassungsdatum;
            set => SetProperty(ref _erfassungsdatum, value);
        }
        public string Benutzer
        {
            get => _benutzer;
            set => SetProperty(ref _benutzer, value);
        }
        public DelegateCommand CmdDurchsuchen { get; }
        public DelegateCommand CmdSpeichern { get; }
        public DateTime? ValutaDatum
        {
            get => _valutaDatum;
            set => SetProperty(ref _valutaDatum, value);
        }
        public bool IsRemoveFileEnabled
        {
            get => _isRemoveFileEnabled;
            set => SetProperty(ref _isRemoveFileEnabled, value);
        }
        private void OnCmdDurchsuchen()
        {
            var openFileDialog = new OpenFileDialog();
            var result = openFileDialog.ShowDialog();
            if (result.GetValueOrDefault())
                _filePath = openFileDialog.FileName;
        }
        private void OnCmdSpeichern()
        {
            if (!HasAllRequiredFieldSet())
            {
                MessageBox.Show("Es müssen alle Pflichtfelder ausgefüllt werden!");
                return;
            }
            if (!IsDocumentSelected())
            {
                MessageBox.Show("Es muss ein Dokument ausgewählt sein.");
                return;
            }
            _documentService.AddDocumentToDms(CreateMetadataItem());
            _navigateBack();
        }
        private MetadataItem CreateMetadataItem()
        {
            var metadataItem = new MetadataItem(ValutaDatum.Value, SelectedTypItem, Stichwoerter)
            {
                Benutzer = Benutzer,
                Bezeichnung = Bezeichnung,
                FilePath = _filePath,
                IsRemoveFileEnabled = IsRemoveFileEnabled,
                Erfassungsdatum = DateTime.Now
            };
            return metadataItem;
        }
        private bool IsDocumentSelected() => !IsNullOrEmpty(_filePath);
        private bool HasAllRequiredFieldSet() => !IsNullOrEmpty(Bezeichnung) && ValutaDatum.HasValue && !IsNullOrEmpty(SelectedTypItem);
    }
}