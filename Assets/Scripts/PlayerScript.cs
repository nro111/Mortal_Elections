using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : GameController {

	public GameController gameController;

	public int health;
	public Slider healthSlider;

	public Animator pMov;


	public enum AttackType {
		Punch,
		Kick,
		Special,
		Block,
		JumpHit
	}
	public AttackType attackType;

	public string[] arrayString;

	void Start ()
	{
		pMov = gameController.P1Ani;

//		P1 = gameManager.playerCharacter;
//		P2 = gameManager.opponentCharacter;

	}

	void Update () {

		switch(attackType)
		{
		case AttackType.Punch:
			//print ("Punch");
			break;
		case AttackType.Kick:
			//animator.Play ("Player_Kick");
			//print ("Kick Anin");
			break;
		case AttackType.Special:
			//print ("Special");
			break;
		case AttackType.JumpHit:
			//print ("JumpHit");
			break;
		default:
			//print ("Hit'em");
			break;
		}

		if (health <= 0) {
			
			//health = 0;

			Destroy (gameObject, 0.5f);
			gameController.GameOver ();

		} 
	}

	public void DamagePlayer(int damage)
	{
		health -= damage;

		healthSlider.value = health;

		
	}

}
