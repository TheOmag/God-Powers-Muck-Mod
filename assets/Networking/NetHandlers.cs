using UnityEngine;
using UnityEngine.SceneManagement;

namespace Muck_GHod_Attack.Networking.handlers
{
    public class var
    {
        public static bool InMultiplayer = false;
        public static int numOfPLayers = 0;
    }
    public class main
    {
        private static bool oneOff = false;
        public static void Update()
        {
            if (SceneManager.GetActiveScene().name != "Menu")
            {
                var.numOfPLayers = GameManager.players.Count;
                if (var.numOfPLayers == 1)
                {
                    var.InMultiplayer = false;
                } else
                {
                    var.InMultiplayer = true;
                }
            }
        }
    }
    public class voids
    {
        public static void RemoveMob(int mobID)
        {
            if (var.InMultiplayer)
            {
                MobManager.Instance.RemoveMob(mobID);
            }
        }
        public static void FreezeMob(int mobID)
        {
            if (var.InMultiplayer)
            {
            }
        }
        public static void KillPlayers(int playerID, Vector3 pos)
        {
            if (var.InMultiplayer)
            {
                GameManager.instance.KillPlayer(playerID, pos);
            }
        }
    }
}
