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

	public bool autoSave = true ;

	//string filePath;

	BinaryFormatter formatter = new BinaryFormatter();
	PersistentData persistentData = new PersistentData();


	// Use this for initialization
	void Start () {

		//filePath = Path.Combine (Application.persistentDataPath, "persistant.dat");

		UpdateTexts ();
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
			persistentData.highScore = score;
		}

		if (autoSave)
			SaveHighscore ();

		UpdateTexts ();
	}

	public void DecrementScore () {
		
		score -= 10 ;
		
		UpdateTexts ();
	}


	public void SaveHighscore () {

		/*using (FileStream stream = File.OpenWrite(filePath)) {

			formatter.Serialize(stream, persistentData);
		}*/
	}
}
