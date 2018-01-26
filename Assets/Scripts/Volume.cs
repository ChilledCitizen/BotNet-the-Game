using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour
{

    // Use this for initialization
    public Slider sliderUI;
	private float previousValue;
    public GameController gameController;

    void Start()
    {

        gameController = FindObjectOfType(typeof(GameController)) as GameController;
       // sliderUI.onValueChanged.AddListener(delegate { ValueChangeCheck(); });

        sliderUI.value = AudioListener.volume;
		previousValue = sliderUI.value;
    }

    void Update()
    {

		if(previousValue != sliderUI.value)
		{
			gameController.SetVolume(sliderUI.value);
			previousValue = sliderUI.value;
		}



    }


}
