using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {


	NavMeshAgent agent;
	public GameObject GatherPoint;

	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		agent.SetDestination(GatherPoint.transform.position);
	
	}
}
