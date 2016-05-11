using UnityEngine;
using System.Collections;

public class AgentExplose : MonoBehaviour 
{
	NavMeshAgent agentE;
	public PopAgent _scriptPopAgent;
	public GameObject explosionVerte;

	public bool canKickAgent;
	public GameObject _hole;
	public float speedAgentE;

	public Score score;
	public int ajoutScore;
	public int enleverScore;


	public float _distanceToHole;
	float onCircle = 1.5f;

	public GameObject bombe;
	public float _distanceToBombe;
	public float distanceBombeDestroy;
	public float timeExplosed = 0.32f;
	Vector3 positionBombe;
	float timerBombe;

	// Use this for initialization
	void Start () 
	{
		agentE = GetComponent<NavMeshAgent>();
		positionBombe = bombe.transform.position;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.gameObject.tag == "AgentEGros") 
		{
			agentE.SetDestination (_hole.transform.position);
			agentE.speed = speedAgentE;
		}

		if (this.gameObject.tag == "AgentEPetit") 
		{
			agentE.SetDestination (new Vector3(Random.insideUnitSphere.x, 0, _hole.transform.position.z));
			agentE.speed = speedAgentE;
		}

		_distanceToHole = Vector3.Distance (_hole.transform.position, transform.position);
	

		if(_distanceToHole < onCircle) 
		{	
			
			// Détruire et enlever des points 
			SoundsPlayer.Instance.MakeAgentArrivalSound();
			_scriptPopAgent.compteurAgent -=1;
			agentE.Stop ();
			Destroy(this.gameObject);


			score.DecrementScore(enleverScore);

			//Debug.Log("Score -1");

		}

		_distanceToBombe = Vector3.Distance(bombe.transform.position, transform.position);

		if(_distanceToBombe < distanceBombeDestroy) 
		{
			bombe.GetComponent<Bonus>().hasExplosed = true;

			SoundsPlayer.Instance.MakeAgentArrivalSound();
			_scriptPopAgent.compteurAgent -=1;
			agentE.Stop ();
			Destroy(this.gameObject);
			GameObject Exploded = Instantiate(explosionVerte, transform.position, Quaternion.identity) as GameObject;
			Destroy (Exploded, timeExplosed);
			score.IncrementScore(ajoutScore);

//			timerBombe += Time.deltaTime;
//
//			if(timerBombe > 1f)
//			{
//				bombe.transform.position = positionBombe;
//				timerBombe = 0;
//			}

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
