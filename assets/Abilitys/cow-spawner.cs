/*using UnityEngine;
using UnityEngine.AI;
public class cow_spawner
{
    //ray
    private static GameObject dot1 = null;
    private static Ray r = new Ray();

    //objects
    private static GameObject cow = null;


    public static void run()
    {
        r = new Ray(PlayerMovement.Instance.GetRb().position + new Vector3(0, 1.4f, 0), PlayerMovement.Instance.playerCam.forward);
        Physics.Raycast(r, 10000);
        RaycastHit hit;
        if (Physics.Raycast(r, out hit))
        {
            *//*            cow = Resources.Load("Assets//PrefabInstance/Cow.prefab") as GameObject;
                        cow.transform.position = hit.point;*//*
            var coww = Resources.Load("Assets//PrefabInstance/Cow.prefab");
            Object.Instantiate<Object>(coww);
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
}*/

