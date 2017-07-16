using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeXt.Daud.Model.Updates;

namespace NeXt.Daud.Model
{
    [PropertyChanged.AddINotifyPropertyChangedInterface]
    public class FirstRunManager
    {
        public FirstRunManager()
        {
            Updater = new UpdateManager();
            Updater.Add(new DelegateUpdateAction(() => { }, "Test First", "Debugging first only", "This description only exists to allow debugging of the view"));
            Updater.Add(new DelegateUpdateAction(() => { }, "Test Second", "Debugging second only", "This description only exists to allow debugging of the view"));
            Updater.Add(FilesystemUpdates.BackupFile("C:\\FicticiousFile.test", "C:\\Backup\\FicticiousFile.test"));
            Updater.Add(FilesystemUpdates.BackupDirectory("C:\\ExampleDirectory", "C:\\Backup\\ExampleDirectory", "restore to default feature"));
        }

        public UpdateManager Updater { get; }

        public bool SeperateSaveGames { get; set; }
    }
}
