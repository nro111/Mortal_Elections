using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenNavigation : MonoBehaviour {

    public static void LoadGameModeScreen() {
		SceneManager.LoadScene ("options_menu");
	}

   public static void LoadStartMenu() {
		SceneManager.LoadScene ("start_menu");
	}

    public static void LoadCharacterSelection() {
		SceneManager.LoadScene ("CharacterSelection");
	}

    public void LoadVenueSelection() {
		DontDestroyOnLoad (GameManager.instance.opponentCharacter);
		DontDestroyOnLoad (GameManager.instance.playerCharacter);
		SceneManager.LoadScene ("SelectVenueScene");
	}

   public void ExitApplication() {
		Application.Quit ();
	}
}
