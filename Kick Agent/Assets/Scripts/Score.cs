using UnityEngine;
using UnityEngine.UI;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Score : MonoBehaviour {

	public Text scoreText;
	public int score = 0;
	public int highScore = 0;

	public bool autoSave = true ;

	BinaryFormatter formatter = new BinaryFormatter();


	// Use this for initialization
	void Start () {

		UpdateTexts ();
	
	}
	
	// Update is called once per frame
	void UpdateTexts () {

		scoreText.text = score.ToString();
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
