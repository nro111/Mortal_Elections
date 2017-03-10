using UnityEngine;
using System.Collections;
using Assets;

// Needed for Google Play Services
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;


public class LoginScript : MonoBehaviour {

	// Use this for initialization
	public void OnClick(){
		
		// authenticate user:
		Social.localUser.Authenticate((bool success) => {
			// handle success or failure
			if (success)
			{
				Social.ReportProgress(Play.achievement_election_season, 100.0f, (bool successful) => {
				});


				ScreenNavigation.LoadGameModeScreen ();
			}
		});
			
	}
}
