using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[System.Serializable]
public class Venue {
	public string venueName;
	public string sceneName;
	public int unlocked;
	public bool isSelectable;
	public Image venueImage;
	public int requiredWins;
}
