using UnityEngine;
using System.Collections;
using Assets;

public class MultiPlayer : MonoBehaviour {

	// Use this for initialization
	public void OnClick() {
		GameManager.instance.mode.SetMultiPlayer ();
	}
}
