using UnityEngine; 
using System.Collections.Generic;

public class PopAgent : MonoBehaviour 
{

	public GameObject agentBPrefab;
	public GameObject agentFPrefab;
	public GameObject agentEPrefab;
	GameObject agentInstance;
	//public float sizePool;

	public float compteurAgent;
	public float sizeRectX1;
	public float sizeRectZ1;
	public float sizeRectX2;
	public float sizeRectZ2;

	public float nbreMaxAgent;

	AgentScript _scriptAgent;
	NavMeshAgent agentNavmesh;

//	float speedAgent;
	public float speedMin;
	public float speedMax;

	int position;
	int typeAgent;

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
		//agentPrefab.SetActive(true);
		//_scriptAgent = agentPrefab.GetComponent<AgentScript>();
		//agentNavmesh = _scriptAgent.GetComponent<NavMeshAgent>();
//		speedAgent = Random.Range(speedMin, speedMax);
	}
	void Update()
	{
//		speedAgent = Random.Range(speedMin, speedMax);
		position = Random.Range(0,1);
		typeAgent = Random.Range(0,3);

		if(compteurAgent < nbreMaxAgent)
		{
			PopAgentB();
		}
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
		//GameObject agentInstance = Instantiate( agentPrefab);
		compteurAgent += 1;



		//agentNavmesh.speed = speedAgent ;
		//agentInstance.tag = "Agent";


		if(typeAgent == 0)
		{
			agentInstance = Instantiate( agentBPrefab);
			agentInstance.SetActive(true);
			// TAG AGENT BASIC
			agentInstance.tag = "AgentB";
			// ADD SCRIPT AGENT BASIC
				
			PositionPop ();


		}

		if(typeAgent == 1)
		{
			 agentInstance = Instantiate( agentFPrefab);
			// TAG AGENT Get OUT OF LIGHT RAPIDlY
			agentInstance.tag = "AgentF";
			// ADD SCRIPT AgentGetOutOfLight

			PositionPop ();
		}

		if(typeAgent == 2) 
		{
			agentInstance = Instantiate( agentEPrefab);
			// Tag Agent Demultiplicateur
			agentInstance.tag = "AgentEGros";
			// Add AgentDemultiplicateur
	
			PositionPop();
		}


		if(agentInstance != null){
			agentInstance.transform.SetParent(transform);
		}
	}

	void PositionPop ()
	{
		if( position == 0)
		{
			agentInstance.transform.position = new Vector3(Random.Range(-sizeRectX1,sizeRectX1),0, Random.Range(-sizeRectZ1,sizeRectZ1));	
		}
		else
		{
			agentInstance.transform.position = new Vector3(Random.Range(-sizeRectX2,sizeRectX2),0, Random.Range(-sizeRectZ2,sizeRectZ2));
		}
	}
}