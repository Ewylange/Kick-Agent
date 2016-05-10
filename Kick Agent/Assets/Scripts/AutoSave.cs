using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Toggle))]
public class AutoSave : MonoBehaviour 
{
	public Score _scriptScore;

	Toggle toggleComponent;
	// Use this for initialization
	void Start () 
	{
		toggleComponent = GetComponent<Toggle>();
		toggleComponent.isOn = _scriptScore.autoSave;
	}

	public void OnToggle() 
	{
		_scriptScore.autoSave = toggleComponent.isOn;
	}
}