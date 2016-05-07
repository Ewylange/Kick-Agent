using UnityEngine; 
using System.Collections.Generic;

public class PopAgent : MonoBehaviour 
{

	public GameObject agentPrefab;
	//public float sizePool;

	public float compteurAgent;
	public float sizeCam;

	public float nbreMaxAgent;

	AgentScript _scriptAgent;
	NavMeshAgent agentNavmesh;

	float speedAgent;
	public float speedMin;
	public float speedMax;

	//	public void PoolSystem ()
	//	{
	//
	//		List<GameObject> listAgent = new List<GameObject>();
	//		for (int i = 0; i < sizePool; i++) 
	//		{
	//
	//			GameObject agentInstance = Instantiate( agentPrefab);
	//			listAgent.Add(agentInstance);
	//		}
	//	}
	void Start()
	{
		agentPrefab.SetActive(true);
		_scriptAgent = agentPrefab.GetComponent<AgentScript>();
		agentNavmesh = _scriptAgent.GetComponent<NavMeshAgent>();
		speedAgent = Random.Range(speedMin, speedMax);
	}
	void Update()
	{
		speedAgent = Random.Range(speedMin, speedMax);
	}

	void FixedUpdate () 
	{
		//PoolSystem();

		if(compteurAgent < nbreMaxAgent)
		{
			PopAgentB();
		}
	}

	void PopAgentB()
	{
		GameObject agentInstance = Instantiate( agentPrefab);
		compteurAgent += 1;
		agentInstance.transform.position = new Vector3(Random.Range(-sizeCam,sizeCam),0, Random.Range(-sizeCam,sizeCam));

		agentNavmesh.speed = speedAgent ;

		agentInstance.SetActive(true);
	}

}