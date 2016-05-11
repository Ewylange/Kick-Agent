using UnityEngine;
using System.Collections;

public class AgentFuyard : MonoBehaviour 
{

	NavMeshAgent agentF;
	public PopAgent _scriptPopAgent;
	public GameObject explosionMagenta;


	public Score score;
	public int ajoutScore;
	public int enleverScore;

	public GameObject _hole;
	public bool canKickAgent;
	public float normalSpeed;
	public float fuiSpeed;
	public float normalAccel;
	public float fuiAccel;

	public float _distanceToHole;
	float _rayonLightHole;
	float onCircle = 1.5f;

	public GameObject bombe;
	public float _distanceToBombe;
	public float distanceBombeDestroy;
	public float timeExplosed = 0.32f;

	float timerBombe;

	enum State : int 
	{
		GOHOLE,
	
		FUI

	}

	State _state;

	// Use this for initialization
	void Start () 
	{
		agentF = GetComponent<NavMeshAgent>();
		_state = State.GOHOLE;


	}
	
	// Update is called once per frame
	void Update () 
	{	

		_distanceToHole = Vector3.Distance (_hole.transform.position, transform.position);


		if(_distanceToHole < onCircle) 
		{	
			//Debug.Log("Agent on Gather Point ");
			// Détruire et enlever des points ? Trouver un truc loufoque ou inhabituel a faire si l'ennemi atteint le point 
			SoundsPlayer.Instance.MakeAgentArrivalSound();
			_scriptPopAgent.compteurAgent -=1;
			agentF.Stop ();
			Destroy(this.gameObject);


			score.DecrementScore(enleverScore);


		}


		_distanceToBombe = Vector3.Distance(bombe.transform.position, transform.position);

		if(_distanceToBombe < distanceBombeDestroy) 
		{
			bombe.GetComponent<Bonus>().hasExplosed = true;
			SoundsPlayer.Instance.MakeAgentArrivalSound();
			_scriptPopAgent.compteurAgent -=1;
			agentF.Stop ();
			Destroy(this.gameObject);
			GameObject Exploded = Instantiate(explosionMagenta, transform.position, Quaternion.identity) as GameObject;
			score.IncrementScore(ajoutScore);
			Destroy (Exploded, timeExplosed);


	
		}
		switch (_state) 
		{

		case State.GOHOLE:
			if (transform.gameObject.tag == "AgentF" && transform.gameObject != null) {

				agentF.SetDestination (_hole.transform.position);
				agentF.speed = normalSpeed;
				agentF.acceleration = normalAccel;
				if (canKickAgent == true /*&& _distanceToHole > 10*/) {
					_state = State.FUI;
				}
			}
			break;

		case State.FUI:
			if (transform.gameObject.tag == "AgentF" && transform.gameObject != null) 
			{
				agentF.acceleration = fuiAccel;
				agentF.speed = fuiSpeed;
				agentF.SetDestination(_hole.transform.position);
	//			if (canKickAgent == false) 
	//			{
	//				_state = State.GOHOLE;
	//				Debug.Log ("Sort de la light");
	//			}
			}
			break;
		}
	
	}

	void OnTriggerEnter(Collider colEnter) 
	{

		if(colEnter.gameObject.tag == "Bulle")
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
