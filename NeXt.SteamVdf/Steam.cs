using Microsoft.Win32;
using NeXt.Vdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeXt.SteamVdf
{
    public class Steam
    {
        private static Lazy<Steam> instance = new Lazy<Steam>(() => new Steam(), false);
        public static Steam Instance => instance.Value;

        private Steam()
        {
            //the steam install folder
            steam_folder = new Lazy<string>(delegate
            {
                var key = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
                key = key.OpenSubKey(@"SOFTWARE\Valve\Steam");
                var folder = key.GetValue("InstallPath") as string;
                return folder;
            },isThreadSafe: true);

            //a list of file paths of steam app folders
            steamapps_list = new Lazy<IReadOnlyList<string>>(delegate
            {
                var list = new List<string>();
                var defaultApps = Path.Combine(Folder, "SteamApps");
                list.Add(defaultApps);

                var desr = VdfDeserializer.FromFile(Path.Combine(defaultApps, "libraryfolders.vdf"));
                var tbl = desr.Deserialize() as VdfTable;

                int i = 1;
                while (tbl.ContainsName(i.ToString()))
                {
                    var p = (tbl[i.ToString()] as VdfString).Content;
                    list.Add(Path.Combine(p, "SteamApps"));
                    i++;
                }

                return list.AsReadOnly();
            },isThreadSafe: true);

            Config = new SteamConfiguration(this);
        }



        private readonly Lazy<string> steam_folder;
        private readonly Lazy<IReadOnlyList<string>> steamapps_list;        
        private readonly Dictionary<string, string> gamePaths = new Dictionary<string, string>();

        private string GetInstallPath(string gameid)
        {
            if (gamePaths.TryGetValue(gameid, out var v)) return v;

            foreach (var apps in steamapps_list.Value)
            {
                if (File.Exists(Path.Combine(apps, $"appmanifest_{gameid}.acf")))
                {
                    var desr = VdfDeserializer.FromFile(Path.Combine(apps, $"appmanifest_{gameid}.acf"));
                    var tbl = desr.Deserialize() as VdfTable;
                    var dirName = (tbl["installdir"] as VdfString).Content;
                    var p = Path.Combine(apps, "common", dirName);
                    gamePaths.Add(gameid, p);
                    return p;
                }
            }


            return null;
        }

        public string Folder => steam_folder.Value;
        public IEnumerable<string> SteamAppsFolders => steamapps_list.Value;
        public string this[string gameid] => GetInstallPath(gameid);

        public SteamConfiguration Config { get; }

    }
}
