using System.IO;

namespace ZbW.Testing.Dms.Client.Services
{
    public class FileTestable
    {
        public virtual void Copy(string sourceFileName, string destFileName, bool overwrite) =>
            File.Copy(sourceFileName, destFileName, overwrite);
    }
}
