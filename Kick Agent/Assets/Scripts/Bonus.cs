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

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (score.score >= 50 )
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
			
//			GameObject bombeInstance = Instantiate(bombe);
//			bombeInstance.transform.position = new Vector3(mousePosition.x, 0, mousePosition.z);
			this.transform.position = new Vector3(mousePosition.x, 0, mousePosition.z);
			GameObject Exploded = Instantiate(explosion, this.transform.position, Quaternion.identity) as GameObject;
			buttonBombe.image.sprite = bombeDesactive;
			activeBombe = false;
			canActiveBombe = false;
			got50 = true;
			Destroy (Exploded, 0.32f);





		}
			

	}

	public void ActivateBombe () 
	{
//		if(canActiveBombe == true )
//		{
//			activeBombe = true;
//		}
		activeBombe = true;
		buttonBombe.image.sprite = bombeActive; 
		// changer le sprite de la bombe aussi
	}


}
