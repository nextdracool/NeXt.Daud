using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeXt.Daud.Model
{
    public class BackupIdentifier : IIdentifiable
    {
        public static IIdentifiable Instance { get; } = new BackupIdentifier();
        private BackupIdentifier() { }
        public Guid Id { get; } = Guid.Empty;
    }
}
