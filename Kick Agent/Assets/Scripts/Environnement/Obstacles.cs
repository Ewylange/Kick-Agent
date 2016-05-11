using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour {
	
	public GameObject obstacles1;
	public GameObject obstacles2;
	public GameObject obstacles3;
	public GameObject obstacles4;


	public float timer1;
	public float timeActive1;
	public float timeDesactive1;

	public float timer2;
	public float timeActive2;
	public float timeDesactive2;

	public float timer3;
	public float timeActive3;
	public float timeDesactive3;

	public float timer4;
	public float timeActive4;
	public float timeDesactive4;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{

		// OBSTACLES 1

		timer1 += Time.deltaTime;

		if(timer1< timeActive1)
		{
			obstacles1.SetActive (true);
		}

		if (timer1 > timeActive1) 
		{
			obstacles1.SetActive (false);
		}
		if (timer1 > timeDesactive1) 
		{
			timer1 = 0;
		}

		/// OBSTACLES 2
		/// 
		timer2 += Time.deltaTime;

		if(timer2< timeActive2)
		{
			obstacles2.SetActive (true);
		}

		if (timer2 > timeActive2) 
		{
			obstacles2.SetActive (false);
		}
		if (timer2 > timeDesactive2) 
		{
			timer2 = 0;
		}

		// OBSTACLES 3

		timer3 += Time.deltaTime;

		if(timer3< timeActive3)
		{
			obstacles3.SetActive (true);
		}

		if (timer3 > timeActive3) 
		{
			obstacles3.SetActive (false);
		}
		if (timer3 > timeDesactive3) 
		{
			timer3 = 0;
		}

		// OBSTACLES 4

		timer4 += Time.deltaTime;

		if(timer4< timeActive4)
		{
			obstacles4.SetActive (true);
		}
			
		if (timer4 > timeActive4) 
		{
			obstacles4.SetActive (false);
		}
		if (timer4 > timeDesactive4) 
		{
			timer4 = 0;
		}


//		TimeActivation (obstacles2,timeActive2, timeDesactive2, timer2);
//		TimeActivation (obstacles3,timeActive3, timeDesactive3, timer3);
//		TimeActivation (obstacles4,timeActive4, timeDesactive4, timer4);
	}
//
//	void TimeActivation (GameObject obstacles, float timeActive, float timeDesactive) 
//	{
//
//		timer += Time.deltaTime;
//
//		if(timer< timeActive)
//		{
//			obstacles1.SetActive (true);
//		}
//
//		if (timer > timeActive) 
//		{
//			obstacles1.SetActive (false);
//		}
//		if (timer > timeDesactive) 
//		{
//			timer = 0;
//		}
//	}
}
