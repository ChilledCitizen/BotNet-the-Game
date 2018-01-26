using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameController : MonoBehaviour
{

    // Use this for initialization

    //RobotController robotController;
    public int robotAmount = 0;
    public GameObject[] robotList;
    public AudioClip gamePlayMusic, menuMusic;
    public AudioSource audioSource;
    private RobotSpawner robotSpawner;
    private bool timed;
    public SceneScript sceneScript;
    private float deltatime;

    public RobotController robotController;
    //public List<GameObject> robotList;
    public enum ChoosenMode
    {
        explosion,
        ramp,
        wall,
        nothing
    }

    //ChoosenMode choosenMode;
    void Awake()
    {
        // DontDestroyOnLoad(gameObject.transform);
    }
    void Start()
    {
        //robotController = FindObjectOfType(typeof(RobotController)) as RobotController;

        sceneScript = FindObjectOfType(typeof(SceneScript)) as SceneScript;
        robotController = FindObjectOfType(typeof(RobotController)) as RobotController;
		robotSpawner = FindObjectOfType(typeof(RobotSpawner)) as RobotSpawner;
		timed = false;
    }

    // Update is called once per frame
    void Update()
    {

        robotList = (GameObject.FindGameObjectsWithTag("Robot"));




        robotAmount = robotList.Length;


        if (Input.GetKey(KeyCode.R))
        {
            sceneScript.LoadLevel(sceneScript.level1);
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            sceneScript.LoadLevel(sceneScript.menu);
        }



        if (!audioSource.isPlaying)
        {
            if (sceneScript.curScene.buildIndex == sceneScript.level1)
            {
                audioSource.clip = gamePlayMusic;
            }
            else
            {
                audioSource.clip = menuMusic;
            }

            audioSource.Play();
        }

        if (!timed)
        {
            deltatime += Time.deltaTime;
        }
        if (deltatime > robotSpawner.spawnRate * 2)
        {	
			timed = true;
            if (robotAmount <= 0)
            {
                sceneScript.LoadLevel(sceneScript.menu);
            }
        }




    }



    public void RobotExplosionClick()
    {
        foreach (var robot in robotList)
        {
            robot.GetComponent<RobotController>().choosenMode = ChoosenMode.explosion;
        }
    }

    public void RobotRampClick()
    {
        foreach (var robot in robotList)
        {
            robot.GetComponent<RobotController>().choosenMode = ChoosenMode.ramp;
        }
    }

    public void RobotWallClick()
    {
        foreach (var robot in robotList)
        {
            robot.GetComponent<RobotController>().choosenMode = ChoosenMode.wall;
        }
    }

    public void RobotNothingClick()
    {
        foreach (var robot in robotList)
        {
            robot.GetComponent<RobotController>().choosenMode = ChoosenMode.nothing;
        }
    }


    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}
