using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public abstract class Selector : MonoBehaviour, ICharacterSelector
	{
		public void deselectCharacter()
		{

		}

		public GameObject selectOpponentCharacter()
		{            
            Transform[] characters = GameObject.Find("CharacterHolder").GetComponentsInChildren<Transform>();
            System.Random randomCharacterSelector = new System.Random();
            int character = randomCharacterSelector.Next(0, 42);
            GameObject selectedCharacter = characters[character].gameObject;

            //until a randomly select characters until character selected is not locked
			while (selectedCharacter.gameObject.name.Contains("locked") || selectedCharacter.gameObject.name.Contains("CharacterHolder"))
            {
                character = randomCharacterSelector.Next(0, 42);
				selectedCharacter = characters[character].gameObject;
            }

            //set the opponent panel as the selected character
            if (!selectedCharacter.gameObject.name.Contains("locked"))
            {
                GameObject.Find("OpponentPanel").GetComponent<Image>().sprite = selectedCharacter.gameObject.GetComponent<Image>().sprite;
            }
            return selectedCharacter;
		}

		//This method uses a raycast to make the desired selection
		//This is used for both character selection and level selection
		public GameObject selectCharacter()
		{            
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
			GameObject selectedCharacter = GameObject.Find("George_Washington");
			if (hit && !hit.collider.gameObject.name.Contains("locked"))
			{
				Debug.Log(hit.collider.gameObject.name);
                
                GameObject.Find("PlayerPanel").GetComponent<Image>().sprite = hit.collider.gameObject.GetComponent<Image>().sprite;                

                //The following is to get the correct image from the game resources and set it as the PlayerPanel bg.                       
				selectedCharacter = hit.collider.gameObject;
            }

			return selectedCharacter; 
		}

		public void confirmSelection()
		{

		}

		public void displayCharacterImage(GameObject gameObject)
		{
			Debug.Log(gameObject.name);
		}

		public void onHover()
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
			if (hit.collider == null)
			{
				Debug.Log("nothing hit");
                //hit.collider.GetComponent<SpriteRenderer>().sprite.u = Color.yellow; 
			}
			else
			{
				print(hit.collider.name);
			}
		}



	}
}
