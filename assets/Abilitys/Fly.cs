/*using System.Collections;
using UnityEngine;

public class Fly
{
    //main
    public static bool flying = false;

    //player body
    private static GameObject player = null;
    private static Rigidbody playerRb = null;
    private static CharacterController cc = null;

    public static void run()
    {
        if (player == null)
        {
            foreach (var p in Resources.FindObjectsOfTypeAll<GameObject>())
            {
                if (p.GetComponent<PlayerMovement>())
                {
                    player = p;
                    playerRb = player.GetComponent<Rigidbody>();
                    cc = player.GetComponent<CharacterController>();
                    cc.enabled = false;
                    flying = true;
                }
            }
        }
        if (flying)
        {
            cc.enabled = true;

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = player.transform.right * x + player.transform.forward * z;
            playerRb.useGravity = false;
            cc.Move(move * main.FlySpeed.Value * Time.deltaTime);
        }
        else
        {
            cc.enabled = false;
        }
    }

    public static void Reset()
    {
        player = null;
        playerRb = null;
        cc = null;
        flying = false;
    }
}

*/