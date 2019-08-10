using System;
using System.Runtime.CompilerServices;

namespace ZbW.Testing.Dms.Client.Model
{
    public class MetadataItem
    {
        public string Stichwoerter { get; set; }
        public string Bezeichnung { get; set; }
        public string Benutzer { get; set; }
        public DateTime Erfassungsdatum { get; set; }
        public string FilePath { get; set; }
        public bool IsRemoveFileEnabled { get; set; }
        public string Type { get; set; }
        public DateTime ValutaDatum { get; set; }
        public MetadataItem() { }
        public MetadataItem(DateTime valutaDatum, string type, string keysord = "")
        {
            ValutaDatum = valutaDatum;
            Type = type;
            Stichwoerter = keysord;
        }
        public MetadataItem(string bezeichnung, DateTime erfassungsdatum, string filePath, bool isRemoveFileEnabled, string type, string stichwoerter, DateTime valutaDatum, string benutzer)
        {
            Bezeichnung = bezeichnung;
            Benutzer = benutzer;
            Erfassungsdatum = erfassungsdatum;
            FilePath = filePath;
            IsRemoveFileEnabled = isRemoveFileEnabled;
            Type = type;
            Stichwoerter = stichwoerter;
            ValutaDatum = valutaDatum;
        }
    }
}