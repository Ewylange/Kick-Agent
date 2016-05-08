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

	public AgentScript _scriptAgent;
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0)) 
		{
			int shot = Random.Range(0,2);
			if (shot == 1){
				SoundsPlayer.Instance.MakeShot1Sound();
			}else {
				SoundsPlayer.Instance.MakeShot2Sound();
			}

			DetectAgent();
		}
		
		
		
	}
	
	void DetectAgent () 
	{
		
		ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	//	Debug.DrawRay (ray.origin, -this.transform.forward * limitDetection);
		
		if(Physics.Raycast(ray, out hitAgent, limitDetection))
		{
			if(hitAgent.transform.tag == "Agent" && _scriptAgent.canKickAgent == true)
			{	
				Debug.Log("Agent Touché !! ");
				// Détruire Agent 
				agentToKill = hitAgent.collider.gameObject;
				Destroy(agentToKill);
				SoundsPlayer.Instance.MakeExplosionSound();
				GameObject Exploded = Instantiate(explosion, hitAgent.transform.position, Quaternion.identity) as GameObject;
				score.IncrementScore();
				Debug.Log("Score + 1");
				// Augmenter le score
				Destroy(Exploded,0.32f);
			}
		}
	}
}
