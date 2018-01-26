using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{

    // Use this for initialization
    public int level1 = 3;
    public int menu = 0;

    public int options = 1;
    public int scoreScreen = 2;
    public Scene curScene;
    void Awake()
    {


		//DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Start()
    {
        curScene = SceneManager.GetActiveScene();
    }



    public void PlayButtonPress()
    {
        SceneManager.LoadScene(level1);
    }

	public void OptionsButtonPress()
	{
		SceneManager.LoadScene(options);
	}

    public void QuitPress()
    {
        Application.Quit();
    }


    public void LoadLevel(int levelID)
    {
        SceneManager.LoadScene(levelID);
    }



}
