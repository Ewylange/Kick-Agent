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



	// Use this for initialization
	void Start () 
	{
		_scriptAgent = agent.GetComponent<AgentScript>();
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
						//Debug.Log("Agent Détruit");
						SoundsPlayer.Instance.MakeExplosionSound ();
						GameObject Exploded = Instantiate (explosionBleu, hitAgent.transform.position, Quaternion.identity) as GameObject;
						// Augmenter le score
						score.IncrementScore ();
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
						SoundsPlayer.Instance.MakeExplosionSound();
						GameObject Exploded = Instantiate(explosionMagenta, hitAgent.transform.position, Quaternion.identity) as GameObject;
						score.IncrementScore();
						Destroy (Exploded, 0.32f);
					}
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
