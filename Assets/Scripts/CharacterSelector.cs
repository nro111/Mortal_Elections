using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
	public class CharacterSelector : Selector
	{
        GameManager gameManager;
		bool once = true;
        public void Start()
		{
            gameManager = GameManager.instance;
			GameObject opponentCharacter = selectOpponentCharacter ();
			gameManager.opponentCharacter = (GameObject) Instantiate(opponentCharacter) ;
        }

		void Update()
		{
            onHover();
           
			if (Input.GetMouseButtonDown(0) && once)
			{					
				once = false;
				GameObject playerCharacter = selectCharacter ();
				gameManager.playerCharacter = (GameObject) Instantiate(playerCharacter); 
            }
            
        }                   
	}
}
