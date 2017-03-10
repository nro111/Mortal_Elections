using UnityEngine;
using System.Collections; 

public class PresidentMovement2 : PlayerScript2 {
	public float moveSpeed;
	//private float maxSpeed = 5f;
	private Vector2 input;
	private PlayerScript p1Script;

	private Rigidbody2D player2;


	private Animator playerMov2;



	// Use this for initialization
	void Start () {
		
		p1Script = gameManager.playerCharacter.GetComponent<PlayerScript> ();
		player2 = this.gameController.P2.GetComponent <Rigidbody2D> ();
		playerMov2 = this.gameController.P2.GetComponent<Animator> ();
		
	}
	
	// Update is called once per frame
	void Update () {
//		if(player2.velocity.magnitude < maxSpeed){
//			player2.AddForce (input * moveSpeed);

		input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxis ("Vertical"));
		print (input);

}

	void OnCollisionEnter2D(Collision2D hit)
	{
//		if (hit.gameObject.tag == "Player")
//		{
//			attackType = AttackType.Punch;
//			p1Script.DamagePlayer (10);
//			print (attackType + " " + p1Script.health);
//			
//			print ("I'm in range of Player"); 
//		}
	}

	void OnCollisionStay2D(Collision2D hit)
	{
		/*if (hit.gameObject.tag == "Player" && Input.GetKeyDown (KeyCode.G)) {
			attackType = AttackType.Block;
			playerMov.Play ("Player_Walk");
			//p1Script.DamagePlayer (10);
			print (attackType + " " + p1Script.health);
		}*/
		if (hit.gameObject.tag == "Player" && Input.GetKeyDown (KeyCode.K)) {
			
			attackType = AttackType.Punch;
			playerMov2.Play ("Hillary_Palm_Strike");
			p1Script.DamagePlayer (10);
			print (attackType + " " + p1Script.health);
		}
		if (hit.gameObject.tag == "Player" && Input.GetKeyDown (KeyCode.G)) {
			
			attackType = AttackType.Kick;
			playerMov2.Play ("Hillary_Kick");
			p1Script.DamagePlayer (20);
			print (attackType + " " + p1Script.health);
		}
		if (hit.gameObject.tag == "Player" && Input.GetKeyDown (KeyCode.H)) {
			attackType = AttackType.Block;
			p1Script.DamagePlayer (0);
			print (attackType + " " + p1Script.health);

		}
		if (hit.gameObject.tag == "Player" && Input.GetKeyDown (KeyCode.J)) {

			attackType = AttackType.JumpHit;
			p1Script.DamagePlayer (5);
			print (attackType + " " + p1Script.health);
		}
	}
}
