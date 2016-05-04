using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {


	NavMeshAgent agent;
	public GameObject GatherPoint;
	public float distanceToGatherPoint;
	public bool canKickAgent;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		agent.SetDestination(GatherPoint.transform.position);
		distanceToGatherPoint =  Vector3.Distance(GatherPoint.transform.position, transform.position);
		if(distanceToGatherPoint < 1.5f) 
		{	
			Debug.Log("Agent on Gather Point ");
			// Détruire et enlever des points ? TRouver un truc loufoque ou inhabituel a faire si l'ennemi atteint le point 

		}
		canKickAgent = false;
		if (distanceToGatherPoint < 10) 
		{
			canKickAgent = true;
		}
	
	}
}
