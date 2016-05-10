using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {

	public Score score;
	public bool canActiveBombe;
	public bool activeBombe;
	public float timer;

	public bool got50;
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (score >= 50  )
		{
			timer += Time.deltaTime;
			if(timer < 2 )
			{
				canActiveBombe = true;
			}

			if(timer > 2)
			{
				got50 = true;
			}

		}

		activeBombe = false;

		if(activeBombe = true)
		{
			
		}



		if(Input.GetMouseButtonDown(0)) 
		{


			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//	Debug.DrawRay (ray.origin, -this.transform.forward * limitDetection);

			if(Physics.Raycast(ray, out hitAgent, limitDetection ))
			{
	}

	void ActivateBombe () 
	{
		if(canActiveBombe == true && got50 == false)
		{
			activeBombe = true;
		}

	}
}
