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
    void Awake()
    {


		DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void PlayButtonPress()
    {
        SceneManager.LoadScene(level1);
    }

	public void OptionsButtonPress()
	{
		SceneManager.LoadScene(options);
	}

}
