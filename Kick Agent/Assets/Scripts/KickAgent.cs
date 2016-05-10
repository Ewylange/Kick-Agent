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

	AgentScript _scriptAgent = null;
	public GameObject agent;
	PopAgent _scriptPopAgent;

	public GameObject agentEPetit;

	// Use this for initialization
	void Start () 
	{
		_scriptAgent = agent.GetComponent<AgentScript>();
		_scriptPopAgent = GetComponent<PopAgent> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0)) 
		{


			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			//	Debug.DrawRay (ray.origin, -this.transform.forward * limitDetection);

			if(Physics.Raycast(ray, out hitAgent, limitDetection ))
			{
				if (hitAgent.transform.tag == "AgentB") {	
					Debug.Log ("Agent Touché !! ");
					// Détruire Agent 
					agentToKill = hitAgent.collider.gameObject;
					Debug.Log (_scriptAgent.canKickAgent);

					if (agentToKill.GetComponent<AgentScript> ().canKickAgent == true) {

						Destroy (agentToKill);
						_scriptPopAgent.compteurAgent -=1;
						//Debug.Log("Agent Détruit");
						SoundsPlayer.Instance.MakeExplosionSound ();
						GameObject Exploded = Instantiate (explosionBleu, hitAgent.transform.position, Quaternion.identity) as GameObject;
						// Augmenter le score
						score.IncrementScore (10);
						//Debug.Log("Score + 1");

						Destroy (Exploded, 0.32f);
					}
				}
				if( hitAgent.transform.tag == "AgentF"   )
				{	
					agentToKill = hitAgent.collider.gameObject;
					if (agentToKill.GetComponent<AgentFuyard> ().canKickAgent == true)
					{
						Destroy(agentToKill);
						_scriptPopAgent.compteurAgent -=1;
						SoundsPlayer.Instance.MakeExplosionSound();
						GameObject Exploded = Instantiate(explosionMagenta, hitAgent.transform.position, Quaternion.identity) as GameObject;
						score.IncrementScore(10);
						Destroy (Exploded, 0.32f);
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
					agentEPetitInstance.transform.tag = "AgentEPetit";

					score.IncrementScore(10);
					Destroy (Exploded, 0.32f);


				}
			}

			if( hitAgent.transform.tag == "AgentEPetit"   )
			{	
				agentToKill = hitAgent.collider.gameObject;
				if (agentToKill.GetComponent<AgentExplose>().canKickAgent == true)
				{
					Destroy(agentToKill);
					SoundsPlayer.Instance.MakeExplosionSound();

					GameObject Exploded = Instantiate(explosionVerte, hitAgent.transform.position, Quaternion.identity) as GameObject;
					score.IncrementScore(10);
					Destroy (Exploded, 0.32f);
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

}
