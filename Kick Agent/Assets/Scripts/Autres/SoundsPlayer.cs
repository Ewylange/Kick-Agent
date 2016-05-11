using UnityEngine;
using System.Collections;

public class SoundsPlayer : MonoBehaviour {


	/// <summary>
	/// Singleton
	/// </summary>
	public static SoundsPlayer Instance ;

	public AudioClip explosionSound;
	public AudioClip agentArrivalSound;
	public AudioClip shot1Sound;
	public AudioClip shot2Sound;

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

	public void MakeShot1Sound (){
		MakeSound (shot1Sound);
	}

	public void MakeShot2Sound (){
		MakeSound (shot2Sound);
	}


	void MakeSound(AudioClip audioclip){
		AudioSource.PlayClipAtPoint (audioclip, transform.position);
	}
}
