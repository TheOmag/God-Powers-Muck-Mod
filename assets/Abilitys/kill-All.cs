using UnityEngine;
using UnityEngine.AI;

public class kill_All
{
    //mob
    public static int modToRemove = 0;
    public static void run()
    {
        foreach (var x in GameObject.FindObjectsOfType<GameObject>())
        {
            try
            {
                if (x.GetComponent<NavMeshAgent>() && !x.GetComponent<Guardian>() || x.GetComponent<AIforFriend>() && !x.GetComponent<Guardian>())
                {
                    modToRemove = x.GetComponent<Mob>().id;
                    MobManager.Instance.mobs.Remove(modToRemove);
                    GameObject.Destroy(x.gameObject);
                    PlayerStatus.Instance.AddKill(1, x.transform.GetComponent<Mob>());
                    Powers.particleVanish(x.transform.position);
                    Muck_GHod_Attack.Networking.handlers.voids.RemoveMob(modToRemove);
                }
            }
            catch { }
        }
        powerChoice.currentAbility = -1;
    }
}

