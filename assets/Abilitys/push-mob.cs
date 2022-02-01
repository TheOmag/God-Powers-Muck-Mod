using UnityEngine;
using UnityEngine.AI;
public class push_mob
{
    //ray
    public static GameObject dot2 = null;
    public static Ray r = new Ray();
    public static void run()
    {
        r = new Ray(PlayerMovement.Instance.GetRb().position + new Vector3(0, 1.4f, 0), PlayerMovement.Instance.playerCam.forward);
        Physics.Raycast(r, 10000);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            if (hit.transform.GetComponent<NavMeshAgent>())
            {
                hit.transform.GetComponent<NavMeshAgent>().velocity = r.direction * 25;
            }
        }
        //dot
        if (main.trailRendererEnabled.Value)
        {
            if (dot2 == null)
            {
                dot2 = new GameObject();
                dot2.AddComponent<TrailRenderer>();
                TrailRenderer x = dot2.GetComponent<TrailRenderer>();
                x.material.SetColor("_Color", Color.yellow);
                x.time = 0.1f;
            }
            dot2.transform.position = hit.point + new Vector3(0, 0.005f, 0);
        }
    }
}

