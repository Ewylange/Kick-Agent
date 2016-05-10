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
		_distanceToMouse = Vector3.Distance(mousePosition, transform.position);


		switch(_state)
		{

			case State.GOHOLE :
			
				agentF.SetDestination(_hole.transform.position);
				agentF.speed = normalSpeed;

				if(_distanceToMouse < 2) 
				{
					_state = State.WAIT;
				}

				break;

			case State.WAIT :

			agentF.SetDestination(_hole.transform.position);
			agentF.speed = slowSpeed;

			timer+= Time.deltaTime;
			if(timer >2)
			{
				_state = State.FUI;
			}
				break;

			case State.FUI :
			agentF.SetDestination(-mousePosition);
			agentF.acceleration = 40;
			agentF.speed = 10;
			if(_distanceToMouse > 10)
			{
				
			}

				break;
		}
	}
}
