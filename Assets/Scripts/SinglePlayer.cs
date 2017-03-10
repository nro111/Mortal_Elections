using UnityEngine;
using System.Collections;

public class SinglePlayer : MonoBehaviour {

	// Use this for initialization
	public void OnClick() {
		GameManager.instance.mode.SetSinglePlayer ();
	}
}
