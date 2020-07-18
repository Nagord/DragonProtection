using PulsarPluginLoader;

namespace DragonProtection
{
    public class Plugin : PulsarPlugin
    {
        public override string Version => "1.3.1";

        public override string Author => "Dragon";

        public override string Name => "DragonProtection";

        public override int MPFunctionality => (int)MPFunction.HostOnly;

        public override string HarmonyIdentifier()
        {
            return "Dragon.DragonProtection";
        }
    }
}
