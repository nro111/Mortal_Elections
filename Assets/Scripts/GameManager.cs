using UnityEngine;
using System.Collections;
using Assets.Scripts;

// Needed for Google Play Services
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject playerCharacter;
	public GameObject opponentCharacter;
	public GameMode mode;
	public Venue venue;
	public uint points { get; set; }
	public Material venueBG;
	public int winCount = 0;

	// Use this for initialization
	void Awake () {
		if (instance == null) {
			instance = this;
		} else if (instance != this) {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
		InitGame ();
	}

	// Do game initializaiton stuff
	void InitGame () {
		instance.mode = GetComponent<GameMode> ();

		// recommended for debugging:
		//PlayGamesPlatform.DebugLogEnabled = true;
		// Activate the Google Play Games platform
		PlayGamesPlatform.Activate();
	}
}
