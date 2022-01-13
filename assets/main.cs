using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
[BepInPlugin(patcher.modPath, patcher.modTitle, patcher.modVersion)]
public class main : BaseUnityPlugin
{
    public static bool active = false;
    public static int modToRemove = 0;
    public static Ray r = new Ray();

    private static bool oneOff = false;
    public void Awake()
    {
        versionChecker.checker.run();
    }
    public void Update()
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
            if (active)
            {
                PlayerStatus.Instance.hp = 100;
                if (powerChoice.currentAbility == 2) //kill all
                {
                    foreach (var x in GameObject.FindObjectsOfType<GameObject>())
                    {
                        try
                        {
                            if (x.GetComponent<NavMeshAgent>())
                            {
                                modToRemove = x.GetComponent<Mob>().id;
                                MobManager.Instance.mobs.Remove(modToRemove);
                                GameObject.Destroy(x.gameObject);
                                PlayerStatus.Instance.AddKill(1, x.transform.GetComponent<Mob>());
                                particleVanish(x.transform.position);
                            }
                        }
                        catch
                        {

                        }
                    }
                    powerChoice.currentAbility = 0;
                }
                if (powerChoice.currentAbility == 1) //lazer
                {
                    r = new Ray(PlayerMovement.Instance.GetRb().position, PlayerMovement.Instance.playerCam.forward);
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
                                particleVanish(hit.transform.position);
                            }
                        }
                        catch
                        {

                        }
                    }
                }
                if (powerChoice.currentAbility == 3) //freeze gun
                {
                    r = new Ray(PlayerMovement.Instance.GetRb().position, PlayerMovement.Instance.playerCam.forward);
                    Physics.Raycast(r, 10000);
                    RaycastHit hit;
                    if (Physics.Raycast(r, out hit))
                    {
                        if (hit.transform.GetComponent<NavMeshAgent>() && hit.transform.GetComponent<NavMeshAgent>().speed != 0)
                        {
                            modToRemove = hit.transform.GetComponent<Mob>().id;
                            MobManager.Instance.mobs.Remove(modToRemove);
                            try
                            {
                                hit.transform.GetComponent<NavMeshAgent>().speed = 0;
                                //GameObject.Destroy(hit.transform.GetComponent<NavMeshAgent>());
                            }
                            catch
                            {
                                Debug.Log("Not a valid mob");
                            }
                            particleVanish(hit.transform.position);
                        }
                    }
                }
            }
        }
        else
        {
            powerChoice.windowActive = false;
        }
    }
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
        /*
             foreach (var x in GameObject.FindObjectsOfType<GameObject>())
            {
                if (x.GetComponent<ParticleFinderClass_reewfwqfwqqvvqvq>())
                {
                    x.GetComponent<ParticleSystem>().Stop();
                    //GameObject.Destroy(x); --- this would make the particles instantly die
                }
            }
            */
    }
    public void OnGUI()
    {
        if (Input.GetKeyDown(KeyCode.G) && active == true) { powerChoice.windowActive = true; }
        if (active == false) { powerChoice.windowActive = false; }
        if (powerChoice.windowActive == true)
        {
            GUI.Window(522652, new Rect(0, 0, Screen.width, Screen.height), powerChoice.Window, "");
        }
        if (errorLog.errorLogEnable)
        {
            GUI.Window(3876573, new Rect(Screen.width - 500, Screen.height - 200, 500, 200), errorLog.errorLogWindow1, "Error log - " + patcher.modTitle + " - " + patcher.modVersion);
        }
        else
        {
            GUI.Window(3876573, new Rect(0, 0, 0, 0), PlaceHolder, "");
        }
    }
    public void PlaceHolder(int windowID)
    {

    }
}

//components to add
public class timerParticle : MonoBehaviour
{
    public GameObject self;
    private float timer = 0;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            self.GetComponent<ParticleSystem>().Stop();
        }
        if (timer >= 6)
        {
            GameObject.Destroy(self);
        }
    }
}
