using UnityEngine;
using System.Collections;

public class AgentExplose : MonoBehaviour 
{
	NavMeshAgent agentE;
	public PopAgent _scriptPopAgent;
	public bool canKickAgent;
	public GameObject _hole;
	public float speedAgentE;

	public Score score;

	public float _distanceToHole;
	float _rayonLightHole;
	float onCircle = 1.5f;

	// Use this for initialization
	void Start () 
	{
		agentE = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.gameObject.tag == "AgentEGros") 
		{
			agentE.SetDestination (_hole.transform.position);
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

	void OnTriggerExit (Collider colExit)
	{
		if(colExit.gameObject.tag == "Bulle")
		{
			canKickAgent = false;
		}
	}
}
