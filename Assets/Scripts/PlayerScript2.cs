using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript2 : GameController {
	//public GameObject GWash;

	private Rigidbody2D P2Rigi;
	public GameController gameController;

	public float Range;

	private float Speed;
	//private PlayerScript p1Script;

	public int health;
	public Slider healthSlider;

	public enum AttackType {
		Punch,
		Kick,
		Special,
		Block,
		JumpHit
	}
	public AttackType attackType;

	public int[] numbers;

	// Use this for initialization
	void Start () {

		P2Rigi = GetComponent <Rigidbody2D> ();
//
//		P1 = (GameObject)Instantiate(gameManager.playerCharacter);
//		P2 = (GameObject)Instantiate(gameManager.opponentCharacter);
		Speed = 40;
	}
	
	// Update is called once per frame
	void Update () {


		// Range = Vector2.Distance (P2.transform.position, P1.transform.position);
//
//		if (Range <= 15f) {
//			Vector2 velocity = new Vector2 ((P2.transform.position.x - P1.transform.position.x) * Speed, (P2.transform.position.y - P1.transform.position.y) * Speed);
//			P2Rigi.velocity = -velocity;
//		}

		switch(attackType)
		{
		case AttackType.Punch:
			//print ("Punch");
			break;
		case AttackType.Kick:
			//print ("Kick");
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
			gameController.Win ();

		}

//		if (p1Script.health <= 0) {
//			//print ("Another player has died ");
//		}
//
	}


	public void DamagePlayer(int damage)
	{
		health -= damage;

		healthSlider.value = health;

	}
}
