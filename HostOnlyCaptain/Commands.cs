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

        public bool Execute(string arguments, int SenderID)
        {
            Global.ProtectionEnabled = !Global.ProtectionEnabled;
            string message = Global.ProtectionEnabled ? "Enabled" : "Disabled, you should turn it back on ASAP. This will be reset to Enabled when the game is restarted";
            Messaging.Notification($"DragonProtection is now {message}");
            return false;
        }

        public bool PublicCommand()
        {
            return false;
        }

        public string UsageExample()
        {
            return $"/{CommandAliases()[0]}";
        }
    }
}
