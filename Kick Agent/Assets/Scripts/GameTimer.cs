using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class GameTimer : MonoBehaviour {

	public Text timeText;

	public float time = 30f;

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
	    
		float realTime = Mathf.Floor(time / 66f) ;
		timeText.text = realTime.ToString();

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
