using UnityEngine;
using System.Collections;

public class SoundsPlayer : MonoBehaviour {


	/// <summary>
	/// Singleton
	/// </summary>
	public SoundsPlayer Instance ;

	public AudioClip explosionSound;
	public AudioClip agentArrivalSound;
	public AudioClip shotSound;

	void Awake (){
		/*if (Instance != null) {
			Debug.LogError("Several Instances");
		}*/
		Instance = this;

	}

	public void MakeExplosionSound (){
		MakeSound (explosionSound);
	}

	public void MakeAgentArrivalSound (){
		MakeSound (agentArrivalSound);
	}

	public void MakeShotSound (){
		MakeSound (shotSound);
	}


	void MakeSound(AudioClip audioclip){
		AudioSource.PlayClipAtPoint (audioclip, transform.position);
	}
}
