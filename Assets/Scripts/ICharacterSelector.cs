using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
	interface ICharacterSelector
	{
		void onHover(); 
		GameObject selectCharacter();
		void deselectCharacter();
		void confirmSelection();
		void displayCharacterImage(GameObject gameObject);
		GameObject selectOpponentCharacter();
	}
}
