using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeXt.Daud.Util;

namespace NeXt.Daud.Model.Updates
{
    public static class FilesystemUpdates
    {
        private abstract class FileSystemAction : UpdateActionBase
        {
            protected FileSystemAction(string source, string target, string label,string reason, string description)
                : base($"[{label}] {Path.GetFileName(source)}", reason, description)
            {
                Source = source;
                Target = target;
            }

            protected readonly string Source;
            protected readonly string Target;
        }

        private class FileBackupAction : FileSystemAction
        {
            public FileBackupAction(string source, string target, string reason) 
                : base(source, target, "Backup File", reason,
                      "Creates a copy of an existing file (overwrites existing target if it exists)")
            { }

            public override void Run() => File.Copy(Source, Target, true);
        }

        private class DirectoryBackupAction : FileSystemAction
        {
            public DirectoryBackupAction(string source, string target, string reason)
                : base(source,target, "Backup Directoy", reason,
                      "Creates a copy of an existing directory and all files in it (overwrites existing target if it exists)")
            { }
            
            public override void Run() => Microsoft.VisualBasic.FileIO.FileSystem.CopyDirectory(Source, Target, true);
        }

        private class FileDeleteAction : FileSystemAction
        {
            public FileDeleteAction(string target, string reason)
                : base(target,target,"Delete File", reason, "Deletes the file if it exists")
            { }

            public override void Run() => File.Delete(Target);
        }

        private class DirectoryDeleteAction : FileSystemAction
        {
            public DirectoryDeleteAction(string target, string reason)
                : base(target, target, "Delete Directory", reason, "Recursively deletes the directory if it exists")
            { }

            public override void Run()
            {
                try
                {
                    Directory.Delete(Target, true);
                }
                catch (DirectoryNotFoundException) { }
            }
        }
        private class CreateDirectoryLinkAction : FileSystemAction
        {
            public CreateDirectoryLinkAction(string source, string target, string reason)
                : base(source, target, "Delete Directory", reason, "Creates \"shortcut\" to a directory to make files accessible without copying them")
            { }

            public override void Run()
            {
                LinkManager.CreateSymbolicLink(Source, Target, LinkManager.SymbolicLinkFlags.Directory);
            }
        }

        #region file operations

        public static IUpdateAction BackupFile(string source, string target, string reason = "safety backup")
            => new FileBackupAction(source, target, reason);

        public static IUpdateAction DeleteFile(string target, string reason)
            => new FileDeleteAction(target, reason);

        #endregion

        #region directory operations

        public static IUpdateAction BackupDirectory(string source, string target, string reason = "safety backup")
            => new DirectoryBackupAction(source, target, reason);

        public static IUpdateAction DeleteDirectory(string target, string reason)
            => new DirectoryDeleteAction(target, reason);

        public static IUpdateAction CreateDirectoryLink(string source, string target, string reason)
            => new CreateDirectoryLinkAction(source, target, reason);

        #endregion

    }
}
