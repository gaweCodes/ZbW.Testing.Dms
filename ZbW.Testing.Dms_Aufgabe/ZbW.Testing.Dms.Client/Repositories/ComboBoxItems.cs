using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ZbW.Testing.Dms.UnitTests")]
[assembly: InternalsVisibleTo("ZbW.Testing.Dms.IntegrationTests")]
namespace ZbW.Testing.Dms.Client.Repositories
{
    internal class ComboBoxItems
    {
        public static List<string> Typ => new List<string> { "Verträge", "Quittungen" };
    }
}