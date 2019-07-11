using System;
using static System.String;

namespace ZbW.Testing.Dms.Client.Model
{
    public class MetadataItem
    {
        public string Stichwoerter { get; set; } = Empty;
        public string Bezeichnung { get; set; }
        public string Benutzer { get; set; }
        public DateTimeOffset Erfassungsdatum { get; set; }
        public string FilePath { get; set; }
        public bool IsRemoveFileEnabled { get; set; }
        public string Type { get; set; }
        public DateTimeOffset ValutaDatum { get; set; }
        public MetadataItem()
        {
        }
        public MetadataItem(string bezeichnung, DateTimeOffset erfassungsdatum, string filePath, bool isRemoveFileEnabled, string type, string stichwoerter, DateTimeOffset valutaDatum, string benutzer)
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