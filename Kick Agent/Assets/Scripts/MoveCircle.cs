using UnityEngine;
using System.Collections;

public class MoveCircle : MonoBehaviour 
{


	void Update ()
	{
		float radius = 0.1f + 0.02f * Mathf.Sin(Time.time * 2.0f);
		GetComponent<Renderer>().material.SetFloat("_Radius", radius);

		float opacity = 0f + 0.3f * Mathf.Sin(Time.time * 10.0f);
		GetComponent<Renderer>().material.SetFloat("_Opacity", radius);
	}
}
