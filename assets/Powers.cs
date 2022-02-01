using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
public class Powers
{
    //main
    public static bool active = false;

    public static GameObject findGround = null;

    //inf
    private static float[] save = new float[] { -1, -1 };

    //ray
    public static Ray r = new Ray();

    public static void Run()
    {
        if (SceneManager.GetActiveScene().name != "Menu")
        {

            if (Input.GetKeyDown(KeyCode.G))
            {
                if (active == false)
                {
                    active = true;
                }
                else
                {
                    active = false;
                }
            }

            //all power code

            //lazer------------------------------------------------------------------------>


            if (powerChoice.currentAbility == 0)
            {
                Death_laser.run();
            }
            else
            {
                Death_laser.dot = null;
            }

            //kill all------------------------------------------------------------------------>


            if (powerChoice.currentAbility == 1)
            {
                kill_All.run();
            }

            //freeze gun------------------------------------------------------------------------>


            if (powerChoice.currentAbility == 2)
            {
                Freeze_gun.run();
            }
            else
            {
                Freeze_gun.dot1 = null;
            }

            //Mob Push------------------------------------------------------------------------>


            if (powerChoice.currentAbility == 3)
            {
                push_mob.run();
            }
            else
            {
                push_mob.dot2 = null;
            }

            //Inf Stamina------------------------------------------------------------------------>


            if (powerChoice.currentAbility == 4)
            {
                if (save[0] == -1)
                {
                    save[0] = PlayerStatus.Instance.stamina;
                }
                PlayerStatus.Instance.stamina = 100f;
            }
            else if (save[0] != -1)
            {
                PlayerStatus.Instance.stamina = save[0];
                save[0] = -1;
            }

            //Inf Health------------------------------------------------------------------------>


            if (powerChoice.currentAbility == 5)
            {
                if (save[1] == -1)
                {
                    save[1] = PlayerStatus.Instance.hp;
                }
                PlayerStatus.Instance.hp = 100f;
            }
            else if (save[1] != -1)
            {
                PlayerStatus.Instance.hp = save[1];
                save[1] = -1;
            }

            //leave laser ------------------------------------------------------------------------>


            if (powerChoice.currentAbility == 6)
            {
                leave_laser.run();
            }
            else
            {
                leave_laser.dot3 = null;
            }

            //No-clip------------------------------------------------------------------------>


            if (powerChoice.currentAbility == 7)
            {
                if (!oneOff)
                {
                    No_clip.run();
                    oneOff1 = false;
                    oneOff = true;
                }
            }
            else if(!oneOff1)
            {
                No_clip.stop();
                oneOff1 = true;
                oneOff = false;
            }
        }
        else
        {
            oneOff1 = true;
            powerChoice.windowActive = false;
            powerChoice.currentAbility = -1; //--------------------------------------------------------
        }
    }
    private static bool oneOff = false;
    public static bool oneOff1 = true;

    //particles
    public static void particleStart(Vector3 p)
    {
        GameObject x = new GameObject();
        x.transform.position = p;
        x.name = "hsrtazzhsjywjhwjywtj";
        x.AddComponent<timerParticle>();
        x.GetComponent<timerParticle>().self = x;
        x.AddComponent<ParticleSystem>();
        ParticleSystem y = x.GetComponent<ParticleSystem>();
        y.GetComponent<Renderer>().material.color = Color.yellow;
        y.Play();
    }
    public static void particleVanish(Vector3 p)
    {
        GameObject x = new GameObject();
        x.transform.position = p;
        x.name = "gargagargaggajdtjshsaagtg";
        x.AddComponent<timerParticle>();
        x.GetComponent<timerParticle>().self = x;
        x.AddComponent<ParticleSystem>();
        ParticleSystem y = x.GetComponent<ParticleSystem>();
        y.Play();
    }
    //other
    public static void FindPos000()
    {
        if (findGround == null)
        {
            findGround = new GameObject();
            var x = findGround;
            x.transform.position = new Vector3(0, 1000, 0);
            r = new Ray(new Vector3(0, 998, 0), Vector3.down);
            Physics.Raycast(r, 100000);
            RaycastHit hit;
            if (Physics.Raycast(r, out hit))
            {
                x.transform.position = hit.point;
            }
        }
    }
}

