using UnityEngine;
using System.Collections;
using GooglePlayGames;
using UnityEngine.SocialPlatforms;

public class ViewLeaderBoard : MonoBehaviour {

	public void OnClick() {
		PlayGamesPlatform.Instance.ShowLeaderboardUI (Play.leaderboard_leading_candidates);
	}
}
