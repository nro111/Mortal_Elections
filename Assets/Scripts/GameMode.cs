using UnityEngine;
using System.Collections;
using Assets;

public class GameMode : MonoBehaviour {

	public enum PLAYER_MODE {
		SINGLE_PLAYER,
		MULTI_PLAYER
	}

	public PLAYER_MODE mode = PLAYER_MODE.SINGLE_PLAYER;

	public void SetSinglePlayer() {
		mode = PLAYER_MODE.SINGLE_PLAYER;
	}

	public void SetMultiPlayer() {
		mode = PLAYER_MODE.MULTI_PLAYER;
	}

	public PLAYER_MODE GetPlayerMode() {
		return mode;
	}
}
