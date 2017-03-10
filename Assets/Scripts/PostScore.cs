using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;
using Assets;

public class PostScore : MonoBehaviour {

	public void OnClick() {

		Social.ReportScore(GameManager.instance.points, Play.leaderboard_leading_candidates, (bool success) => {
			// handle success or failure
		});
			
	}
}
