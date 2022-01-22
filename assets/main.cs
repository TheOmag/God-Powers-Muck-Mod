using BepInEx;
using BepInEx.Configuration;
using System;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
[BepInPlugin(patcher.modPath, patcher.modTitle, patcher.modVersion)]
public class main : BaseUnityPlugin
{
    public static bool active = false;
    public static int modToRemove = 0;

    //raycasting
    public static GameObject dot = null;
    public static GameObject dot1 = null;
    public static Ray r = new Ray();

    private static bool oneOff = false;

    //config
    private static ConfigEntry<bool> trailRendererEnabled;
    public void Awake()
    {
        if (patcher.IsModABeta)
        {
            errorLog.errorText = "Note this is a beta and some features may not work!";
            errorLog.errorLogEnable = true;
        }
        ConfigFile config = new ConfigFile(Path.Combine(Paths.ConfigPath, "God Powers.cfg"), true);

        // body
        trailRendererEnabled = config.Bind<bool>("Config", "Enabled", true, "If the trail is turned on or not");
        crafterbotsFolderCheck.crafterbotsFolder.run();
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
                                particleVanish(hit.transform.position);
                            }
                        }
                        catch
                        {

                        }
                        //dot
                        if (trailRendererEnabled.Value)
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
                else
                {
                    dot = null;
                }
                if (powerChoice.currentAbility == 3) //freeze gun
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
                            try
                            {
                                hit.transform.GetComponent<NavMeshAgent>().speed = 0;
                                //GameObject.Destroy(hit.transform.GetComponent<NavMeshAgent>());
                            }
                            catch
                            {
                                Debug.LogError("Not a valid mob");
                            }
                            particleVanish(hit.transform.position);
                        }
                    }
                    //dot
                    if (trailRendererEnabled.Value)
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
                else
                {
                    dot1 = null;
                }
            }
            if (powerChoice.currentAbility != 0)
            { 
                PlayerStatus.Instance.hp = 100;
            }
        }
        else
        {
            powerChoice.windowActive = false;
            powerChoice.currentAbility = 0;
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
        if (announcements.UI.newVersion)
        {
            GUI.Window(42874, new Rect(Screen.width / 2 - 140, Screen.height / 2 - 300, 220, 220), announcements.UI.Window, announcements.UI.annoucementTitle);
        }
        else
        {
            GUI.Window(42874, new Rect(0, 0, 0, 0), PlaceHolder, "");
        }
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
