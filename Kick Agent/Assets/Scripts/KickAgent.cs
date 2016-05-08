using UnityEngine;
using System.Collections;

public class KickAgent : MonoBehaviour 
{
	public Score score;
	RaycastHit hitAgent;
	Ray ray;
	float limitDetection = 1000;
	GameObject agentToKill;

	public GameObject explosion;

	AgentScript _scriptAgent;
	public GameObject agent;

	LayerMask shader;

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
				if( hitAgent.transform.tag == "Agent" )
				{	
					Debug.Log("Agent Touché !! ");
					// Détruire Agent 
					agentToKill = hitAgent.collider.gameObject;
					Debug.Log(_scriptAgent.canKickAgent);
					if( _scriptAgent.canKickAgent == true)
					{
						Destroy(agentToKill);
						Debug.Log("Agent Détruit");
						SoundsPlayer.Instance.MakeExplosionSound();
						GameObject Exploded = Instantiate(explosion, hitAgent.transform.position, Quaternion.identity) as GameObject;
						// Augmenter le score
						score.IncrementScore();
						Debug.Log("Score + 1");

						Destroy(Exploded,0.32f);
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
	
//	void DetectAgent () 
//	{
//		
//		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
//	//	Debug.DrawRay (ray.origin, -this.transform.forward * limitDetection);
//
//		if(Physics.Raycast(ray, out hitAgent, limitDetection ))
//		{
//			if( hitAgent.transform.tag == "Agent" )
//			{	
//				Debug.Log("Agent Touché !! ");
//				// Détruire Agent 
//				agentToKill = hitAgent.collider.gameObject;
//				if( _scriptAgent.canKickAgent == true)
//				{
//					Destroy(agentToKill);
//					Debug.Log("Agent Détruit");
//					SoundsPlayer.Instance.MakeExplosionSound();
//					GameObject Exploded = Instantiate(explosion, hitAgent.transform.position, Quaternion.identity) as GameObject;
//					// Augmenter le score
//					score.IncrementScore();
//					Debug.Log("Score + 1");
//					
//					Destroy(Exploded,0.32f);
//				}
//			}
//		}
//	}
}
