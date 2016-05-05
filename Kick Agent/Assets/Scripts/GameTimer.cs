using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GameTimer : MonoBehaviour {

	public Text timeText;

	public float time = 512f;

	public GameObject menuPause;

	// Use this for initialization
	void Start () {

		UpdateTexts ();
		menuPause.SetActive (false);
	
	}
	void Update (){

		DecrementTimer ();
	}

	void UpdateTexts () {
	    
		timeText.text = time.ToString();

	}

	public void DecrementTimer(){

		time --;

		if (time <= 0) {

			Time.timeScale = 0f;
			time = 0;
			menuPause.SetActive(true);
		}

		UpdateTexts ();
	}
}
