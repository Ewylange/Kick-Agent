using UnityEngine;
using System.Collections;

public class AgentScript : MonoBehaviour {



	NavMeshAgent agentB;
	public float agentSpeed;
	public GameObject explosionBleu;

	public Score score;
	public int ajoutScore;
	public int enleverScore;

	public GameObject _bombe;
	public float _distanceToBombe;
	Vector3 positionBombe;


	public GameObject GatherPoint;
	public float distanceToGatherPoint;
	public float rayonGatherPoint;
	public bool canKickAgent = false;

	public float distanceCircleRight;
	float onCircle = 1.5f;
	public PopAgent _scriptPopAgent;

	public float _rotateSpeed ;
	public float _angleSpeed;

	// Use this for initialization
	void Start () 
	{
		agentB = GetComponent<NavMeshAgent>();
		positionBombe = _bombe.transform.position;
	
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

		_distanceToBombe = Vector3.Distance(_bombe.transform.position, transform.position);

		if(_distanceToBombe < 2) 
		{
			//Debug.Log("Agent on Gather Point ");
			// Détruire et enlever des points ? Trouver un truc loufoque ou inhabituel a faire si l'ennemi atteint le point 
			SoundsPlayer.Instance.MakeAgentArrivalSound();
			Destroy(this.gameObject);
			_scriptPopAgent.compteurAgent -=1;
			GameObject Exploded = Instantiate (explosionBleu, transform.position, Quaternion.identity) as GameObject;
			Destroy (Exploded, 0.32f);
			score.IncrementScore(ajoutScore);
			_bombe.transform.position = positionBombe;

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
