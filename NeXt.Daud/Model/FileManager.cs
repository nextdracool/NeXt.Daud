using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NeXt.Daud.Model
{
    public class FileManager
    {
        public static string ConfigFileName => Path.Combine(Environment.CurrentDirectory, "config.json");

        public string BaseDirectory(IIdentifiable idf) => Path.Combine(Environment.CurrentDirectory, idf.Id.ToString());
        public string SavesDirectory(IIdentifiable idf) => Path.Combine(BaseDirectory(idf), "Saves");
        public string SettingsDirectory(IIdentifiable idf) => Path.Combine(BaseDirectory(idf), "Config");
    }
}
