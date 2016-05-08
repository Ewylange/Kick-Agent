using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {

	public Score score;

	NavMeshAgent agent;
	public GameObject GatherPoint;
	public float distanceToGatherPoint;
	public float rayonGatherPoint;
	public bool canKickAgent;
//	public float distanceToPoint;
//	public float rayonPoint;
	public float distanceCircleRight;
	float onCircle = 1.5f;
	public PopAgent _scriptPopAgent;

//	public GameObject pointLeft;
//	public float rayonPointLeft = 4.5f;
//
//	public GameObject pointTopRight;
//	public float rayonPointTopRight;


	// Use this for initialization
	void Start () 
	{
		agent = GetComponent<NavMeshAgent>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(agent.tag =="Agent")
		{
			agent.SetDestination(GatherPoint.transform.position);
		}
		distanceToGatherPoint =  Vector3.Distance(GatherPoint.transform.position, transform.position);
		if(distanceToGatherPoint < onCircle) 
		{	
			//Debug.Log("Agent on Gather Point ");
			// Détruire et enlever des points ? Trouver un truc loufoque ou inhabituel a faire si l'ennemi atteint le point 
			SoundsPlayer.Instance.MakeAgentArrivalSound();
			Destroy(this.gameObject);
			_scriptPopAgent.compteurAgent -=1;

			score.DecrementScore();

			Debug.Log("Score -1");

		}
		//canKickAgent = true;
		//canKickAgent = true;
//		if (distanceToGatherPoint <= rayonGatherPoint) 
//		{
//			canKickAgent = true;
//		}
		//AgentInLight(pointLeft, rayonPointLeft);
		//AgentInLight(pointTopRight, rayonPointTopRight);

	}

//	void AgentInLight(GameObject centerCircle, float rayonPoint)
//	{
//		distanceToPoint = Vector3.Distance(centerCircle.transform.position, transform.position);
//		if (distanceToPoint <= rayonPoint) 
//		{	
//			Debug.Log("Distance TO KICK ");
//			canKickAgent = true;
//		}
////		else
////		{
////			canKickAgent = false;
////		}
//	}


	void OnTriggerEnter(Collider col) 
	{
		
		if(col.gameObject.tag == "Bulle")
		{
			canKickAgent = true;
		}
	}
}
