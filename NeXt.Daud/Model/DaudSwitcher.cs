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
        protected const string DishonoredUpk = "DishonoredGameFull_P.upk";
        protected abstract string DishonoredUi { get; }


        protected abstract string DlcUpk { get; }
        protected abstract string DishonoredStartNormal { get; }

        protected string DishonoredStartDaud => $"start {Path.GetFileNameWithoutExtension(DlcUpk)}";
        
        public virtual void Enable()
        {
            //backup all affected files
            File.Copy(Path.Combine(CookedPcConsole, DishonoredUpk), Path.Combine(LocalPath, DishonoredUpk), true);
            Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(LocalPath, DishonoredUi)));
            File.Copy(Path.Combine(DishonoredUiPath, DishonoredUi), Path.Combine(LocalPath, DishonoredUi), true);

            //create the new upk
            File.Copy(Path.Combine(CookedPcConsole, DishonoredUpk), Path.Combine(CookedPcConsole, DlcUpk), true);

            //change the config
            string ini = File.ReadAllText(Path.Combine(DishonoredUiPath, DishonoredUi));
            ini = ini.Replace(DishonoredStartNormal, DishonoredStartDaud);
            File.WriteAllText(Path.Combine(DishonoredUiPath, DishonoredUi), ini);
        }

        public virtual void Disable()
        {
            //delete the new upk
            File.Delete(Path.Combine(CookedPcConsole, DlcUpk));

            //change the config
            string ini = File.ReadAllText(Path.Combine(DishonoredUiPath, DishonoredUi));
            ini = ini.Replace(DishonoredStartDaud, DishonoredStartNormal);
            File.WriteAllText(Path.Combine(DishonoredUiPath, DishonoredUi), ini);
        }

        protected string DishonoredUiPath => Path.Combine(Locator.Instance[DishonoredId], "DishonoredGame", "DLC", "PCConsole");
        protected string CookedPcConsole => Path.Combine(Locator.Instance[DishonoredId], "DishonoredGame", "CookedPCConsole");
        protected string LocalPath => Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
    }

    public class KnifeOfDunwallSwitcher : DaudSwitcher
    {
        protected override string DishonoredUi => "DLC06\\DishonoredUI.ini";
        protected override string DlcUpk => "DLC06_Dishonored1_P.upk";
        protected override string DishonoredStartNormal => "start DLC06_DishonoredGameFull_P";
    }

    public class BrigmoreWitchesSwitcher : DaudSwitcher
    {
        protected override string DishonoredUi => "DLC07\\DishonoredUI.ini";
        protected override string DlcUpk => "L_DLC07_Dishonored1_P.upk";
        protected override string DishonoredStartNormal => "start L_DLC07_GameFull_P";
        private const string DlcUp = "DLC07\\L_DLC07_GameFull_P.upk";


        //TODO: delete DLC save files

        public override void Enable()
        {
            //backup all affected files
            File.Copy(Path.Combine(CookedPcConsole, DishonoredUpk), Path.Combine(LocalPath, DishonoredUpk), true);
            Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(LocalPath, DlcUp)));
            File.Copy(Path.Combine(DishonoredUiPath, DlcUp), Path.Combine(LocalPath, DlcUp), true);

            //exchange file
            File.Delete(Path.Combine(DishonoredUiPath, DlcUp));
            File.Copy(Path.Combine(CookedPcConsole, DishonoredUpk), Path.Combine(DishonoredUiPath, DlcUp));
        }

        public override void Disable()
        {
            File.Delete(Path.Combine(DishonoredUiPath, DlcUp));
            File.Copy(Path.Combine(LocalPath, DlcUp), Path.Combine(DishonoredUiPath, DlcUp));
        }
    }
}
