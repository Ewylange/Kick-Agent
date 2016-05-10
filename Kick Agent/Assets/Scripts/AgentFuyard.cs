using UnityEngine;
using System.Collections;

public class AgentFuyard : MonoBehaviour 
{

	NavMeshAgent agentF;
	public PopAgent _scriptPopAgent;

	public Score score;

	public GameObject _hole;
	public bool canKickAgent;
	public float normalSpeed;
	public float fuiSpeed;
	public float normalAccel;
	public float fuiAccel;

	public float _distanceToHole;
	float _rayonLightHole;
	float onCircle = 1.5f;



	enum State : int 
	{
		GOHOLE,
		INLIGHTHOLE,
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
//		Vector3 directionFuite = new Vector3(Random.Range(-1,1),0, Random.Range(-1,1));
//		Vector3 directionFuite2 = new Vector3(-1,0,1);

		if(_distanceToHole < onCircle) 
		{	
			//Debug.Log("Agent on Gather Point ");
			// Détruire et enlever des points ? Trouver un truc loufoque ou inhabituel a faire si l'ennemi atteint le point 
			SoundsPlayer.Instance.MakeAgentArrivalSound();
			_scriptPopAgent.compteurAgent -=1;
			agentF.Stop ();
			Destroy(this.gameObject);


			score.DecrementScore(10);

			//Debug.Log("Score -1");

		}
		switch (_state) 
		{

		case State.GOHOLE:
			if (transform.gameObject.tag == "AgentF") {

				agentF.SetDestination (_hole.transform.position);
				agentF.speed = normalSpeed;
				agentF.acceleration = normalAccel;
				if (canKickAgent == true && _distanceToHole > 10) {
					_state = State.FUI;
					Debug.Log ("Passe a l'etat Fui");
				}
			}
			break;

		case State.FUI:
			if (transform.gameObject.tag == "AgentF") 
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
