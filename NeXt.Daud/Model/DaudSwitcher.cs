using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NeXt.Daud.Model
{
    public abstract class DaudSwitcher
    {
        private const string DishonoredId = "205100";
        private const string DishonoredUpk = "DishonoredGameFull_P.upk";
        protected abstract string DishonoredUI { get; }


        protected abstract string DlcUpk { get; }
        protected abstract string DishonoredStartNormal { get; }

        private string DishonoredStartDaud => $"start {Path.GetFileNameWithoutExtension(DlcUpk)}";
        
        public void Enable()
        {
            //backup all affected files
            File.Copy(Path.Combine(CookedPcConsole, DishonoredUpk), Path.Combine(LocalPath, DishonoredUpk), true);
            Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(LocalPath, DishonoredUI)));
            File.Copy(Path.Combine(DishonoredUIPath, DishonoredUI), Path.Combine(LocalPath, DishonoredUI), true);

            //create the new upk
            File.Copy(Path.Combine(CookedPcConsole, DishonoredUpk), Path.Combine(CookedPcConsole, DlcUpk), true);

            //change the config
            string ini = File.ReadAllText(Path.Combine(DishonoredUIPath, DishonoredUI));
            ini = ini.Replace(DishonoredStartNormal, DishonoredStartDaud);
            File.WriteAllText(Path.Combine(DishonoredUIPath, DishonoredUI), ini);
        }

        public void Disable()
        {
            //delete the new upk
            File.Delete(Path.Combine(CookedPcConsole, DlcUpk));

            //change the config
            string ini = File.ReadAllText(Path.Combine(DishonoredUIPath, DishonoredUI));
            ini = ini.Replace(DishonoredStartDaud, DishonoredStartNormal);
            File.WriteAllText(Path.Combine(DishonoredUIPath, DishonoredUI), ini);
        }

        private string DishonoredUIPath => Path.Combine(Locator.Instance[DishonoredId], "DishonoredGame", "DLC", "PCConsole");
        private string CookedPcConsole => Path.Combine(Locator.Instance[DishonoredId], "DishonoredGame", "CookedPCConsole");
        private string LocalPath => Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    }

    public class KnifeOfDunwallSwitcher : DaudSwitcher
    {
        protected override string DishonoredUI => "DLC06\\DishonoredUI.ini";
        protected override string DlcUpk => "DLC06_Dishonored1_P.upk";
        protected override string DishonoredStartNormal => "start DLC06_DishonoredGameFull_P";
    }

    public class BrigmoreWitchesSwitcher : DaudSwitcher
    {
        protected override string DishonoredUI => "DLC07\\DishonoredUI.ini";
        protected override string DlcUpk => "L_DLC07_Dishonored1_P.upk";
        protected override string DishonoredStartNormal => "start L_DLC07_GameFull_P";
    }
}
