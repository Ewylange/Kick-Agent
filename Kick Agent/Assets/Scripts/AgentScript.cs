using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {



	NavMeshAgent agentB;
	public float agentSpeed;
	public GameObject explosionBleu;

	public Score score;
	public int ajoutScore;
	public int enleverScore;

	public GameObject bombe;
	public float distanceToBombe;
	public float distanceBombeDestroy;
	public float timeExplosed = 0.32f ;
	Vector3 positionBombe;
	float timerBombe;


	public GameObject GatherPoint;
	public float distanceToGatherPoint;
	public float rayonGatherPoint;
	public bool canKickAgent = false;

	public float distanceCircleRight;
	float onCircle = 2f;
	public PopAgent _scriptPopAgent;



	// Use this for initialization
	void Start () 
	{
		agentB = GetComponent<NavMeshAgent>();
		positionBombe = bombe.transform.position;

	
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

			score.DecrementScore(enleverScore);

			//Debug.Log("Score -1");

		}

		distanceToBombe = Vector3.Distance(bombe.transform.position, transform.position);

		if(distanceToBombe < distanceBombeDestroy) 
		{
			
			//Debug.Log("Agent on Gather Point ");
			// Détruire et enlever des points ? Trouver un truc loufoque ou inhabituel a faire si l'ennemi atteint le point 
			SoundsPlayer.Instance.MakeAgentArrivalSound();
			Destroy(this.gameObject);
			_scriptPopAgent.compteurAgent -=1;
			GameObject Exploded = Instantiate (explosionBleu, transform.position, Quaternion.identity) as GameObject;
			Destroy (Exploded, timeExplosed);
			score.IncrementScore(ajoutScore);

			timerBombe += Time.deltaTime;
			if(timerBombe > 1f)
			{
				bombe.transform.position = positionBombe;
				timerBombe = 0;
			}

		}
	
	}



	void OnTriggerEnter(Collider col) 
	{
		
		if(col.gameObject.tag == "Bulle")
		{
			canKickAgent = true;
		}
	}

	void OnTriggerExit (Collider colExit)
	{
		if(colExit.gameObject.tag == "Bulle")
		{
			canKickAgent = false;
		}
	}

}
