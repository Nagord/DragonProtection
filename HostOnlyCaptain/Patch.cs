using HarmonyLib;
using UnityEngine;

namespace HostOnlyCaptain
{
    [HarmonyPatch(typeof(PLServer), "SetPlayerAsClassID")]
    class Patch
    {
        static bool Prefix(ref int classID, ref int playerID)
        {
            if (!PhotonNetwork.isMasterClient)
            {
                return true;
            }
            if (classID == 0 && playerID != 0)
            {
                Debug.Log("[DragonWarning] Someone is trying to Become Captain without your permission. This could be okay.");
                PLServer.Instance.AddNotification("[DragonWarning] Someone is trying to become captain without your permission This could be okay.", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, true);
                return false;
            }
            if (classID != 0 && playerID == 0)
            {
                Debug.Log("[DragonWarning] Someone is trying to remove you from captain");
                PLServer.Instance.AddNotification("[DragonWarning] Someone is trying to remove you from captain!", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, true);
                return false;
            }
            if (classID < -1 || classID > 4)
            {
                Debug.Log("[DragonWarning] Someone is trying to set someone to a non-existant class. Class:" + classID);
                PLServer.Instance.AddNotification("[DragonWarning] Someone is trying to someone to a non-existant class!", PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, true);
                return false;
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(PLServer), "RemoveBot")]
    class RemoveBotPatch
    {
        static bool Prefix(ref int classID)
        {
            PLPlayer player = PLServer.Instance.GetCachedFriendlyPlayerOfClass(classID);
            if (player != null && !player.IsBot)
            {
                Debug.Log("[DragonWarning] Someone is trying to remove remove Player of class " + classID);
                PLServer.Instance.AddNotification("[DragonWarning] Someone is trying to remove Player of class " + classID, PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, true);
                return false;
            }
            return true;
        }
    }
    [HarmonyPatch(typeof(PLServer), "ServerRemoveCrewBotPlayer")]
    class RemoveCrewBotPlayerPatch
    {
        static bool Prefix(ref int inPlayerID)
        {
            PLPlayer player = PLServer.Instance.GetPlayerFromPlayerID(inPlayerID);
            if (player != null && !player.IsBot)
            {
                Debug.Log("[DragonWarning] Someone is trying to delete PlayerID " + inPlayerID);
                PLServer.Instance.AddNotification("[DragonWarning] Someone is trying to delete PlayerID " + inPlayerID, PLNetworkManager.Instance.LocalPlayerID, PLServer.Instance.GetEstimatedServerMs() + 6000, true);
                return false;
            }
            return true;
        }
    }
}
