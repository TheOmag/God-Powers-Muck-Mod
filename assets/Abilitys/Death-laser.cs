using UnityEngine;
using UnityEngine.AI;
public class Death_laser
{
    //raycasting
    public static GameObject dot = null;
    public static Ray r = new Ray();

    //mob 
    public static int modToRemove = 0;

    public static void run()
    {
        r = new Ray(PlayerMovement.Instance.GetRb().position + new Vector3(0, 1.4f, 0), PlayerMovement.Instance.playerCam.forward);
        Physics.Raycast(r, 10000);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            try
            {
                if (hit.transform.GetComponent<NavMeshAgent>())
                {
                    modToRemove = hit.transform.GetComponent<Mob>().id;
                    MobManager.Instance.mobs.Remove(modToRemove);
                    GameObject.Destroy(hit.transform.gameObject);
                    PlayerStatus.Instance.AddKill(1, hit.transform.GetComponent<Mob>());
                    Powers.particleVanish(hit.transform.position);
                    //Muck_GHod_Attack.Networking.handlers.voids.RemoveMob(modToRemove);
                    //Muck_GHod_Attack.Networking.handlers.voids.KillPlayers(hit.transform.GetComponent<Player>().id, hit.transform.position);
                }
            }
            catch
            {

            }
            //dot
            if (main.trailRendererEnabled.Value)
            {
                if (dot == null)
                {
                    dot = new GameObject();
                    dot.AddComponent<TrailRenderer>();
                    TrailRenderer x = dot.GetComponent<TrailRenderer>();
                    x.material.SetColor("_Color", Color.yellow);
                    x.time = 0.1f;
                }
                dot.transform.position = hit.point + new Vector3(0, 0.005f, 0);
            }
        }
    }
}

