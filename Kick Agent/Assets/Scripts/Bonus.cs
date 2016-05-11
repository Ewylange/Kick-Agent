using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bonus : MonoBehaviour {

	public Score score;
	public bool canActiveBombe;
	public bool activeBombe;
	public float timer;

	public bool got50;
	public GameObject explosion;

	Ray ray;
	RaycastHit hit;
	//public GameObject bombe;

	private Vector3 mousePosition;
	public Button buttonBombe;

	public Sprite bombeDesactive;
	public Sprite bombeCanActivate;
	public Sprite bombeActive;

	public bool hasExplosed;
	public float timerBombe;
	Vector3 positionBombe;

	// Use this for initialization
	void Start () 
	{
		positionBombe = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (score.score >= 300 )
		{
			timer += Time.deltaTime;
			if(timer < 2 )
			{
				canActiveBombe = true;
				buttonBombe.image.sprite = bombeCanActivate;
			}

			if(timer > 2 && activeBombe == true)
			{
				got50 = true;
			}

		}

	

		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);



		if(Input.GetMouseButtonDown(0) && activeBombe == true) 
		{
			this.transform.position = new Vector3(mousePosition.x, 0, mousePosition.z);
			GameObject Exploded = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
			buttonBombe.image.sprite = bombeDesactive;
			activeBombe = false;
			canActiveBombe = false;
			got50 = true;
			Destroy (Exploded, 0.5f);

		}

		if(hasExplosed == true)
		{
			timerBombe += Time.deltaTime;
			if(timerBombe > 1f)
			{
				transform.position = positionBombe;
				timerBombe = 0;
				hasExplosed = false;
			}
		}

			

	}

	public void ActivateBombe () 
	{

		activeBombe = true;
		buttonBombe.image.sprite = bombeActive; 
	}


}
