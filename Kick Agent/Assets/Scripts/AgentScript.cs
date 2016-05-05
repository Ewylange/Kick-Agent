using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {

	public Score score;

	NavMeshAgent agent;
	public GameObject GatherPoint;
	public float distanceToGatherPoint;
	public bool canKickAgent;
	public float activKickGatherPoint;
	public float distanceCircleRight;
	float onCircle = 1.5f;


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
		if(distanceToGatherPoint < onCircle) 
		{	
			Debug.Log("Agent on Gather Point ");
			// Détruire et enlever des points ? Trouver un truc loufoque ou inhabituel a faire si l'ennemi atteint le point 
			Destroy(this.gameObject);
			score.DecrementScore();
			Debug.Log("Score -1");
		}
		//canKickAgent = false;
		canKickAgent = true;
		if (distanceToGatherPoint < activKickGatherPoint) 
		{
			canKickAgent = true;
		}
	
	}
}
