using UnityEngine;
using System.Collections;

public class KickAgent : MonoBehaviour 
{
	public Score score;
	RaycastHit hitAgent;
	Ray ray;
	float limitDetection = 1000;
	GameObject agentToKill;

	public GameObject explosionBleu;
	public GameObject explosionVerte;
	public GameObject explosionMagenta;
	public float timeExplosion = 0.32f;
	public int scoreIncreaseBlue;
	public int scoreIncreaseMagenta;
	public int scoreIncreaseBigGreen;
	public int scoreIncreaseLittleGreen;

//	AgentScript _scriptAgent;
	public GameObject agent;
	PopAgent _scriptPopAgent;

	public GameObject agentEPetit;

	// Use this for initialization
	void Start () 
	{
		//_scriptAgent = agent.GetComponent<AgentScript>();
		_scriptPopAgent = GetComponent<PopAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0)) 
		{


			ray = Camera.main.ScreenPointToRay(Input.mousePosition);


			if(Physics.Raycast(ray, out hitAgent, limitDetection ))
			{
				if (hitAgent.transform.tag == "AgentB") 
				{	

					agentToKill = hitAgent.collider.gameObject;


					if (agentToKill.GetComponent<AgentScript> ().canKickAgent == true) {


						Destroy(agentToKill, explosionBleu, scoreIncreaseBlue);
					}
				}
				if( hitAgent.transform.tag == "AgentF")
				{	
					agentToKill = hitAgent.collider.gameObject;

					if (agentToKill.GetComponent<AgentFuyard> ().canKickAgent == true)
					{
						Destroy(agentToKill, explosionMagenta, scoreIncreaseMagenta);
					}
				}
			}

			if( hitAgent.transform.tag == "AgentEGros"   )
			{	
				agentToKill = hitAgent.collider.gameObject;
				if (agentToKill.GetComponent<AgentExplose>().canKickAgent == true)
				{
					
					Destroy(agentToKill);
					_scriptPopAgent.compteurAgent -=1;
					SoundsPlayer.Instance.MakeExplosionSound();
					GameObject Exploded = Instantiate(explosionVerte, hitAgent.transform.position, Quaternion.identity) as GameObject;
					GameObject agentEPetitInstance = Instantiate (agentEPetit, hitAgent.transform.position,Quaternion.identity)as GameObject;
					GameObject agentEPetitInstance2 = Instantiate (agentEPetit, hitAgent.transform.position,Quaternion.identity)as GameObject;

					agentEPetitInstance.transform.tag = "AgentEPetit";
					agentEPetitInstance2.transform.tag = "AgentEPetit";


					score.IncrementScore(scoreIncreaseLittleGreen);
					Destroy (Exploded, timeExplosion);


				}
			}

			if( hitAgent.transform.tag == "AgentEPetit"   )
			{	
				agentToKill = hitAgent.collider.gameObject;
				if (agentToKill.GetComponent<AgentExplose>().canKickAgent == true)
				{

					Destroy(agentToKill, explosionVerte, scoreIncreaseBigGreen);
				}
			}
		
		
			
			int shot = Random.Range(0,2);
			if (shot == 1){
				SoundsPlayer.Instance.MakeShot1Sound();
			}else {
				SoundsPlayer.Instance.MakeShot2Sound();
			}


		}
		
		
		
	}

	void Destroy(GameObject objectDestroyed, GameObject explosion, int scoreDecrease)
	{
		Destroy(objectDestroyed);
		GameObject Exploded = Instantiate(explosion, hitAgent.transform.position, Quaternion.identity) as GameObject;
		score.IncrementScore(scoreDecrease);
		Destroy (Exploded, timeExplosion);
		SoundsPlayer.Instance.MakeExplosionSound();
	}

}
