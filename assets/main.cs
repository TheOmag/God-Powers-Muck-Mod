using BepInEx;
using BepInEx.Configuration;
using System.IO;
using UnityEngine.AI;
using UnityEngine;
using UnityEngine.SceneManagement;
[BepInPlugin(patcher.modPath, patcher.modTitle, patcher.modVersion)]
public class main : BaseUnityPlugin
{
    //config
    public static ConfigEntry<bool> trailRendererEnabled;
    public static ConfigEntry<float> pushSpeed;
    //public static ConfigEntry<float> FlySpeed;

    public void Awake()
    {
        if (patcher.IsModABeta)
        {
            errorLog.errorText = "Note this is a beta and some features may not work!";
            errorLog.errorLogEnable = true;
        }
        //config
        ConfigFile config = new ConfigFile(Path.Combine(Paths.ConfigPath, "God Powers.cfg"), true);

        // body
        trailRendererEnabled = config.Bind<bool>("Config", "Enabled", true, "If the trail is turned on or not");
        pushSpeed = config.Bind<float>("Config", "Push Mob Speed", 25, "");
        //FlySpeed = config.Bind<float>("Config", "Fly speed", 50, "");

        crafterbotsFolderCheck.crafterbotsFolder.run();
    }
    public void Update()
    {
        Powers.Run();
        if(SceneManager.GetActiveScene().name == "Menu")
        {
            Powers.oneOff1 = true;
        }
        else
        {
            //Fly.Reset();
        }
        //popoutManager.main.Update();
    }

    private static bool oneOff1 = false;
    public void OnGUI()
    {
        if (announcementsPopout.InGameUI.newVersion)
        {
            GUI.Window(42874, new Rect(Screen.width / 2 - 140, Screen.height / 2 - 300, 220, 220), announcementsPopout.InGameUI.Window, announcementsPopout.InGameUI.annoucementTitle);
        }
        else if (announcementsPopout.InGameUI.normalAnnouncement)
        {
            GUI.Window(42874, new Rect(Screen.width / 2 - 140, Screen.height / 2 - 300, 220, 220), announcementsPopout.InGameUI.Window, announcementsPopout.InGameUI.annoucementTitle);
        }
        else
        {
            GUI.Window(42874, new Rect(0, 0, 0, 0), PlaceHolder, "");
        }
        if (Input.GetKeyDown(KeyCode.G) && Powers.active == true) { powerChoice.windowActive = true; }
        if (Powers.active == true)
        {
            if (!oneOff1)
            {
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                oneOff1 = true;
            }
        }
        else if (oneOff1 == true)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            oneOff1 = false;
        }

        if (Powers.active == false) { powerChoice.windowActive = false; }
        if (powerChoice.windowActive == true) { GUI.Window(522652, new Rect(0, 0, Screen.width, Screen.height), powerChoice.Window, ""); }
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

public class AIforFriend : MonoBehaviour
{
    public GameObject self;
    private void Awake()
    {
        GameObject.Destroy(self.GetComponent<Mob>());
    }
    private void Update()
    {
        var x = self.GetComponent<NavMeshAgent>();
       x.destination = Powers.findGround.transform.position;
    }
}
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
