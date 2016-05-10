using UnityEngine;
using UnityEngine.UI;

using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class Score : MonoBehaviour {

	public Text scoreText;
	public Text menuScoreText;
	public Text highScoreText;
	public Text menuHighScoreText;
	public int score = 0;
	[HideInInspector]public int highScore = 0;

	public bool autoSave = true ;



	//string filePath;

	BinaryFormatter formatter = new BinaryFormatter();
	PersistentData persistentData = new PersistentData();

	string filePath;


	// Use this for initialization
	void Start () 
	{

		filePath = Path.Combine (Application.persistentDataPath, "persistant.dat");
		LoadHighScore();
		UpdateTexts ();
	}
	
	// Update is just a test
	void Update(){

		if (Input.GetKeyDown (KeyCode.A)) 
		{

			IncrementScore(2);
		}
	}
	void UpdateTexts () 
	{

		scoreText.text = score.ToString();
		menuScoreText.text = score.ToString ();
		highScoreText.text = highScore.ToString ();
		menuHighScoreText.text = highScore.ToString ();

	}

	public void IncrementScore (int pointIncrease) 
	{

		score += pointIncrease ;

		if (score > highScore) 
		{

			highScore = score;
			persistentData.highScore = score;
		}

		SaveHighscore();
		if (autoSave)
			SaveHighscore ();

		UpdateTexts ();
	}

	public void DecrementScore (int pointDecrease) 
	{
		
		score -= pointDecrease ;
		
		UpdateTexts ();
	}




	public void SaveHighscore () 
	{

		using (FileStream stream = File.OpenWrite(filePath)) 
		{

			formatter.Serialize(stream, persistentData);
		}
	}


	public void LoadHighScore () 
	{
		try 
		{
			using (FileStream stream = File.OpenRead(filePath))
			{
				persistentData = formatter.Deserialize(stream)as PersistentData;
			}
		}
		catch(FileNotFoundException)
		{
			Debug.Log("No persistent data to load");
		}
		catch(InvalidCastException)
		{
			Debug.LogWarning("Persistent data class has changed");
		}
	}
}
