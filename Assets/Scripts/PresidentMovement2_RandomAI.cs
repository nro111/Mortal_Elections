using UnityEngine;
using System.Collections; 
using Assets;

public class PresidentMovement2_RandomAI : PlayerScript2 {
	public float moveSpeed;
	private Vector2 input;
	private PlayerScript p1Script;
	private float fireRate = 0.5f;
	private float nextFire = 0.0f;
    private Animator playerMov;
	private bool attackTrigger = false;
	private bool beginTrigger = false;
	private bool rightTrigger = false;
	private bool leftTrigger = false;

	public enum AI_MOVES {
		WALK,
		PUNCH,
		KICK,
		NUMBER_OF_MOVES
	}

	private delegate void AttackDelegate();
	private AttackDelegate[] attackArray = new AttackDelegate[(int) AI_MOVES.NUMBER_OF_MOVES];

	public void Walk() {
		if (true) {
			uint move = (uint)(Mathf.Floor (Random.value * 2));
			if (move == 1) {
				PlayerMovement.simulatedButton = "Left";
				if (!leftTrigger) {
					transform.position += Vector3.left * moveSpeed * Time.deltaTime;
				}
				Debug.Log ("Walk Move is Left Position Is" + transform.position.x);
			} else {
				PlayerMovement.simulatedButton = "Right";
				if (!rightTrigger) {
					 transform.position += Vector3.right * moveSpeed * Time.deltaTime;
				}
				Debug.Log ("Walk Move is Right Position Is " + transform.position.x);
			}
			playerMov.Play ("Player_Walk");
		}
	}

	public void Strike () {
		Debug.Log ("Update Move is Strike");
		if (attackTrigger) {
			attackType = AttackType.Punch;
			playerMov.Play ("Player_Palm_Strike");
			p1Script.DamagePlayer (10);
			print (attackType + " " + p1Script.health);
		}
	}

	public void Kick () {
		Debug.Log ("Update Move is Kick");
		if (attackTrigger) {
			attackType = AttackType.Kick;
			playerMov.Play ("Player_Kick");
			p1Script.DamagePlayer (20);
			print (attackType + " " + p1Script.health);
		}
	}
		
	// Use this for initialization
	void Start () {
		
		// p1Script = gameController.P1.GetComponent<PlayerScript> ();
		p1Script = GameObject.Find("GWash").GetComponent<PlayerScript>();
		playerMov = GetComponent<Animator> ();

		attackArray [(uint)AI_MOVES.WALK] = Walk;
		attackArray [(uint)AI_MOVES.KICK] = Kick;
		attackArray [(uint)AI_MOVES.PUNCH] = Strike;
	}
	
	// Update is called once per frame
	void Update () {
		
		if ((Time.time > nextFire) && beginTrigger) {
			uint move = (uint)Mathf.Floor (Random.value * (int)(AI_MOVES.NUMBER_OF_MOVES));
			Debug.Log ("Update Move is " + move);
			attackArray [move] ();
			nextFire = Time.time + fireRate;
		}
			
	}

	void OnCollisionEnter2D(Collision2D hit)
	{
		if (hit.gameObject.tag == "Player") {
			attackTrigger = true;
		}

		if (hit.gameObject.CompareTag ("Floor")) {
			beginTrigger = true;
		}

		if (hit.gameObject.CompareTag("Right Cube")) {
			rightTrigger = true;
			leftTrigger = false;
		}

		if (hit.gameObject.CompareTag("Left Cube")) {
			rightTrigger = false;
			leftTrigger = true;
		}
	}

	void OnCollisionExit2D(Collision2D hit)
	{
		if (hit.gameObject.tag == "Player") {
			attackTrigger = false;
		}

		if (hit.gameObject.CompareTag("Right Cube")) {
			rightTrigger = false;					
		}

		if (hit.gameObject.CompareTag("Left Cube")) {
			leftTrigger = false;
		}
	}

	void OnCollisionStay2D(Collision2D hit)
	{
		if (hit.gameObject.tag == "Player") {
			attackTrigger = true;
		}
		
		if (hit.gameObject.CompareTag("Right Cube")) {
			rightTrigger = true;					
		}

		if (hit.gameObject.CompareTag("Left Cube")) {
			leftTrigger = true;
		}
	}
}
