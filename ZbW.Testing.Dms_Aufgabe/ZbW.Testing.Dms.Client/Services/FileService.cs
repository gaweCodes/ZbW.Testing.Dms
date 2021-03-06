﻿using System;
using System.IO;
using System.Runtime.CompilerServices;
using ZbW.Testing.Dms.Client.Exceptions;

[assembly: InternalsVisibleTo("ZbW.Testing.Dms.UnitTests")]
[assembly: InternalsVisibleTo("ZbW.Testing.Dms.IntegrationTests")]
namespace ZbW.Testing.Dms.Client.Services
{
    internal class FileService
    {
        public FileTestable FileTestable { private get; set; }
        public void CreateValutaFolderIfNotExists(string path) => Directory.CreateDirectory(path);
        public FileService() => FileTestable = new FileTestable();
        public void RemoveDocumentOnSource(string path) => File.Delete(path);
        public void CopyDocumentToTarget(string sourcePath, string targetPath)
        {
            try
            {
                FileTestable.Copy(sourcePath, targetPath, true);
            }
            catch (Exception e)
            { 
                throw new CouldNotCopyFileException("File konnte nicht kopiert werden", e);
            }
        }
        public string GetNewFileName(string typeName, string fileName, Guid guid)
        {
            var fileExtension = GetFileExtension(fileName);
            return $"{guid}_{typeName}.{fileExtension}";
        }
        public string GetFileExtension(string fileName)
        {
            var splittedByPoint = fileName.Split('.');
            return splittedByPoint[splittedByPoint.Length - 1];
        }

    }
}
