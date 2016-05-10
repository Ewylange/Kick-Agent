using UnityEngine;
using System.Collections;

public class AgentrunAway : MonoBehaviour {

	NavMeshAgent agentF;
	public PopAgent _scriptPopAgent;

	public Score score;

	public GameObject _hole;
	public bool canKickAgent;

	public float _distanceToHole;
	public float _distanceToMouse;
	float onCircle = 1.5f;

	private Vector3 mousePosition;
	public float timer;

	public float normalSpeed;
	public float slowSpeed;

	enum State : int 
	{
		GOHOLE,
		WAIT,
		FUI

	}

	State _state;

	// Use this for initialization
	void Start () 
	{
		agentF = GetComponent<NavMeshAgent>();
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


			score.DecrementScore(10);

			//Debug.Log("Score -1");

		}

		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		_distanceToMouse = Vector3.Distance( transform.position, mousePosition);


		switch(_state)
		{

			case State.GOHOLE :
			if(agentF.transform.tag == "AgentF")
			{
				agentF.SetDestination(_hole.transform.position);
				agentF.speed = normalSpeed;
			}
			if(_distanceToMouse > 98 && _distanceToMouse < 108) 
				{
					_state = State.WAIT;
				}

				break;

			case State.WAIT :
			if(agentF.transform.tag == "AgentF")
			{
				agentF.SetDestination(_hole.transform.position);
				agentF.speed = slowSpeed;
			}
			Debug.Log("WAIT");
			timer+= Time.deltaTime;
			if(timer > 0.5f)
			{
				_state = State.FUI;
				timer =0;
			}
				break;

			case State.FUI :
			Debug.Log("FUI");
			if(agentF.transform.tag == "AgentF")
			{
				agentF.SetDestination(-mousePosition.normalized * 20);
				agentF.acceleration = 40;
				agentF.speed = 10;
			}
			if(_distanceToMouse > 108 || _distanceToMouse < 98)
			{
				_state =State.GOHOLE;
			}

				break;
		}
	}
}
