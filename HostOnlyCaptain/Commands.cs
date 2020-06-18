using PulsarPluginLoader.Chat.Commands;
using PulsarPluginLoader.Utilities;

namespace DragonProtection
{
    class Global
    {
        public static bool ProtectionEnabled = true;
    }
    class Commands : IChatCommand
    {
        public string[] CommandAliases()
        {
            return new string[] { "dragonprotection", "dp"};
        }

        public string Description()
        {
            return "enables and disables protection";
        }

        public bool Execute(string arguments)
        {
            Global.ProtectionEnabled = !Global.ProtectionEnabled;
            string message = Global.ProtectionEnabled ? "Enabled" : "Disabled";
            Messaging.Notification("DragonProtection is now " + message);
            return false;
        }

        public string UsageExample()
        {
            return $"/{CommandAliases()[0]}";
        }
    }
}
