using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using Assets.Scripts;
using System.IO;

public class VenueManager : MonoBehaviour {

	public GameObject venueButton;
	public Venue selectedVenue;
	public Transform spacer;
	public List<Venue> venueList;


	// Use this for initialization
	void Start () {
		FillVenueList();
	}

	void FillVenueList()
	{
		GameManager gameManager = GameManager.instance;
		Sprite img;

		foreach (var venue in venueList) {
			GameObject newButton = Instantiate (venueButton) as GameObject;

			VenueButton button = newButton.GetComponent<VenueButton>();

			if (gameManager.winCount >= venue.requiredWins) {
				button.venueText.text = venue.venueName;
				button.venueImage = venue.venueImage;
				button.sceneName = venue.sceneName;
				button.unlocked = venue.unlocked;
				button.venue = venue;
				button.GetComponent<Button> ().interactable = venue.isSelectable;

				img = venue.venueImage.sprite;
			} else {
				button.venueText.text = "Locked";
				button.sceneName = "lockedScene";
				button.unlocked = 0;
				button.GetComponent<Button> ().interactable = false;

				/*if (System.IO.File.Exists ("Assets/Backgrounds/locked.png")) {
					var bytes = System.IO.File.ReadAllBytes ("Assets/Backgrounds/locked.png");
					var tex = new Texture2D (1, 1);
					tex.LoadImage (bytes);
					button.venueImage.sprite = tex;
				} else {
					var tex = Resources.Load("locked", typeof(Sprite)) as Sprite;
					button.venueImage.sprite = tex;
				}*/
				img = Resources.Load("locked", typeof(Sprite)) as Sprite;
				//button.venueImage.sprite = tex;
				//button.GetComponent<SpriteRenderer> ().sprite = tex;
			}

			foreach (Transform child in newButton.transform) {
				if (child.name == "ImagePanel") {
					foreach (Transform image in child.transform) {
						if (image.name == "Image")
							image.GetComponent<Image> ().sprite = img;
					}
				}
			}

			newButton.GetComponent<Button> ().onClick.AddListener(() => selectVenue(button.venue));
			newButton.transform.SetParent (spacer, false);
		}

		selectVenue (venueList [0]);

		GameObject.Find("FightButton").GetComponent<Button> ().onClick.AddListener(() => loadVenue(selectedVenue));
		GameObject.Find("BackButton").GetComponent<Button> ().onClick.AddListener(() => SceneManager.LoadScene("CharacterSelection"));
	}
		
	void selectVenue(Venue venue)
	{
		foreach (Transform child in spacer) {
			foreach (Transform imagePanel in child) {
				if (imagePanel.name == "ImagePanel") {
					if (child.GetComponent<VenueButton> ().venue == venue) {
						this.selectedVenue = venue;
						imagePanel.GetComponent<Image> ().color = new Color ((float)0.73, (float)0.12, 0);
					} else {
						imagePanel.GetComponent<Image> ().color = new Color (1, 1, 1, (float)0.39);
					}
				}
			}
		}
	}

	void loadVenue(Venue venue)
	{
		GameManager gameManager = GameManager.instance;
		gameManager.venue = venue;
		SceneManager.LoadScene("Fight");
	}
}
