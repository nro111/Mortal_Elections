using UnityEngine;
using System.Collections;

public class CameraHandler : MonoBehaviour {

	// Use this for initialization
	public float targetRatio = 16f/10f; //The aspect ratio you did for the game.
	void Start () {
		Camera cam = GetComponent<Camera>();
		cam.aspect = targetRatio;
	}
}
