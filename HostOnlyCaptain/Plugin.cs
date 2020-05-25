using PulsarPluginLoader;

namespace HostOnlyCaptain
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "1.2.1";

        public override string Author => "Dragon";

        public override string Name => "HostOnlyCaptain";

        public override string HarmonyIdentifier()
        {
            return "Dragon.HostOnlyCaptain";
        }
    }
}
