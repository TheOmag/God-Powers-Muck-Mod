using UnityEngine;
using UnityEngine.AI;

public class leave_laser
{
    //raycasting
    public static GameObject dot3 = null;
    public static Ray r = new Ray();

    //mob
    public static void run()
    {
        r = new Ray(PlayerMovement.Instance.GetRb().position + new Vector3(0, 1.4f, 0), PlayerMovement.Instance.playerCam.forward);
        Physics.Raycast(r, 10000);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            try
            {
                if (hit.transform.GetComponent<Mob>())
                {
                    Powers.FindPos000();
                    MobManager.Instance.mobs.Remove(hit.transform.GetComponent<Mob>().id);
                    GameObject.Destroy(hit.transform.GetComponent<Mob>());
                    GameObject.Destroy(hit.transform.GetComponent<RotateWhenRangedAttack>());
                    //hit.transform.gameObject.AddComponent<AIforFriend>().self = hit.transform.gameObject;
                    hit.transform.GetComponent<NavMeshAgent>().destination = Powers.findGround.transform.position;
                    Powers.particleVanish(hit.transform.position);
                }
            }
            catch
            {
                Debug.Log(Powers.findGround.transform.position.ToString());
            }
        }
        //dot
        if (main.trailRendererEnabled.Value)
        {
            if (dot3 == null)
            {
                dot3 = new GameObject();
                dot3.AddComponent<TrailRenderer>();
                TrailRenderer x = dot3.GetComponent<TrailRenderer>();
                x.material.SetColor("_Color", Color.yellow);
                x.time = 0.1f;
            }
            dot3.transform.position = hit.point + new Vector3(0, 0.005f, 0);
        }
    }
}

