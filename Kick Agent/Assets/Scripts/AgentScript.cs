using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {

	public Score score;

	NavMeshAgent agentB;
	public float agentSpeed;
	public GameObject GatherPoint;
	public float distanceToGatherPoint;
	public float rayonGatherPoint;
	public bool canKickAgent = false;

	public float distanceCircleRight;
	float onCircle = 1.5f;
	public PopAgent _scriptPopAgent;



	// Use this for initialization
	void Start () 
	{
		agentB = GetComponent<NavMeshAgent>();
	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		if(agentB.tag =="AgentB")
		{
			agentB.SetDestination(GatherPoint.transform.position);
			agentB.speed = agentSpeed;
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

			//Debug.Log("Score -1");

		}


	
	}



	void OnTriggerEnter(Collider col) 
	{
		
		if(col.gameObject.tag == "Bulle")
		{
			canKickAgent = true;
		}
	}
}
