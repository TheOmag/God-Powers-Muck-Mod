using UnityEngine;
using UnityEngine.AI;
public class Freeze_gun
{    
    //mob
    public static int modToRemove = 0;
    //ray
    public static GameObject dot1 = null;
    public static Ray r = new Ray();

    public static void run()
    {
        r = new Ray(PlayerMovement.Instance.GetRb().position + new Vector3(0, 1.4f, 0), PlayerMovement.Instance.playerCam.forward);
        Physics.Raycast(r, 10000);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            if (hit.transform.GetComponent<NavMeshAgent>() && hit.transform.GetComponent<NavMeshAgent>().speed != 0)
            {
                modToRemove = hit.transform.GetComponent<Mob>().id;
                MobManager.Instance.mobs.Remove(modToRemove);
                GameObject.Destroy(hit.transform.GetComponent<Mob>()); 
                GameObject.Destroy(hit.transform.GetComponent<RotateWhenRangedAttack>());
                //Muck_GHod_Attack.Networking.handlers.voids.RemoveMob(modToRemove);
                try
                {
                    hit.transform.GetComponent<NavMeshAgent>().speed = 0;
                    //GameObject.Destroy(hit.transform.GetComponent<NavMeshAgent>());
                }
                catch
                {
                    Debug.LogError("Not a valid mob");
                }
                Powers.particleVanish(hit.transform.position);
            }
        }
        //dot
        if (main.trailRendererEnabled.Value)
        {
            if (dot1 == null)
            {
                dot1 = new GameObject();
                dot1.AddComponent<TrailRenderer>();
                TrailRenderer x = dot1.GetComponent<TrailRenderer>();
                x.material.SetColor("_Color", Color.yellow);
                x.time = 0.1f;
            }
            dot1.transform.position = hit.point + new Vector3(0, 0.005f, 0);
        }
    }
}

