using UnityEngine;
using UnityEngine.UI;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Score : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;
	public int score = 0;
	[HideInInspector]public int highScore = 0;
	public GameObject newHighscore;

	public bool autoSave = true ;
	public Vector3 pos;

	BinaryFormatter formatter = new BinaryFormatter();


	// Use this for initialization
	void Start () {

		UpdateTexts ();
		pos = new Vector3(459f,539f,0f);
	}
	
	// Update is just a test
	void Update(){

		if (Input.GetKeyDown (KeyCode.A)) {

			IncrementScore();
		}
	}
	void UpdateTexts () {

		scoreText.text = score.ToString();
		highScoreText.text = highScore.ToString ();
	}

	public void IncrementScore () {

		score += 10 ;

		if (score > highScore) {

			highScore = score;
		}

		if (autoSave)
			SaveHighscore ();

		UpdateTexts ();
	}

	public void SaveHighscore () {


	}
}
