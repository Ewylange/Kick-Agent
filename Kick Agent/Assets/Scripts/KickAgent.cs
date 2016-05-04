﻿using UnityEngine;
using System.Collections;

public class KickAgent : MonoBehaviour 
{
	
	RaycastHit hitAgent;
	Ray ray;
	float limitDetection = 1000;
	
	public AgentScript _scriptAgent;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0)) 
		{
			DetectAgent();
		}
		
		
		
	}
	
	void DetectAgent () 
	{
		
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		Debug.DrawRay (ray.origin, -this.transform.forward * limitDetection);
		
		if(Physics.Raycast(ray, out hitAgent, limitDetection))
		{
			if(hitAgent.transform.tag == "Agent" && _scriptAgent.canKickAgent == true)
			{	
				Debug.Log("Agent Touché !! ");
				// Détruire Agent 
				// Augmenter le score 
			}
		}
	}
}