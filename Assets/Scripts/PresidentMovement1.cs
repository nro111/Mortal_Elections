using UnityEngine;
using System.Collections;

public class PresidentMovement1 : PlayerScript {
	
	public float moveSpeed;
	private float maxSpeed = 5f;
	private Vector2 input;
	private PlayerScript2 p2Script;

	private Animator playerMov;

	private Rigidbody2D player;



	// Use this for initialization
	void Start () {
        player = new Rigidbody2D();
		p2Script = gameManager.opponentCharacter.GetComponent<PlayerScript2> ();
		playerMov = this.gameController.P1.GetComponent<Animator> ();
		player = this.gameController.P1.GetComponent <Rigidbody2D> ();
		
	}

	// Update is called once per frame
	void Update () {

			if (player.velocity.magnitude < maxSpeed) {
				player.AddForce (input * moveSpeed);
			}
			if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.LeftArrow)) {
				playerMov.Play ("Hillary_Walk");
			}

			input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxis ("Vertical"));
			print (input);
	}

	void OnCollisionEnter2D(Collision2D hit)
	{
		if (hit.gameObject.tag == "Player2")
		{
			print ("I'm in range of Player 2"); 
		}
	}

	void OnCollisionStay2D(Collision2D hit)
	{
		if (Input.GetKeyDown (KeyCode.Space))
		{
			playerMov.Play ("Hillary_Jump");
		}
		if (Input.GetKeyDown (KeyCode.G))
		{
			playerMov.Play ("Hillary_Palm_Strike");
		}
		if (Input.GetKeyDown (KeyCode.K))
		{
			playerMov.Play ("Hillary_Kick");
		}
			
		if (hit.gameObject.tag == "Player2" && Input.GetKeyDown (KeyCode.G))
		{
			attackType = AttackType.Punch;
			playerMov.Play ("Hillary_Palm_Strike");
			if (p2Script.attackType.Equals("Block"))
			{
				p2Script.DamagePlayer (5);	
			}
			p2Script.DamagePlayer (10);
			print (attackType + " " + p2Script.health);
		}
		if (hit.gameObject.tag == "Player2" && Input.GetKeyDown (KeyCode.K))
		{
			attackType = AttackType.Kick;
			playerMov.Play ("Hillary_Kick");
			p2Script.DamagePlayer (20);
			print (attackType + " " + p2Script.health);
		}
		if (hit.gameObject.tag == "Player2" && Input.GetKeyDown (KeyCode.H))
		{
			attackType = AttackType.Block;
			p2Script.DamagePlayer (0);
			print (attackType + " " + p2Script.health);

		}
		if (hit.gameObject.tag == "Player2" && Input.GetKeyDown (KeyCode.J))
		{

			attackType = AttackType.JumpHit;
			p2Script.DamagePlayer (5);
			print (attackType + " " + p2Script.health);
		}
	}
}
