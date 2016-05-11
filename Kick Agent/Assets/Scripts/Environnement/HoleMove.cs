using UnityEngine;
using System.Collections;

public class HoleMove : MonoBehaviour {

	public GameObject _position1;
	public GameObject _position2;
	public GameObject _position3;
	public GameObject _position4;
	public GameObject _position5;

	public float timer;



	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		int position = Random.Range(1,5);
		timer += Time.deltaTime;

		if(position == 1 && timer > 5)
		{
			timer = 0;
			transform.position = _position1.transform.position;
		}

		if(position == 2 && timer > 5)
		{
			timer = 0;
			transform.position = _position2.transform.position;
		}

		if(position == 3 && timer > 5)
		{
			timer = 0;
			transform.position = _position3.transform.position;
		}
	}
}
