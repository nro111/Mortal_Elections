using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Assets.Scripts;

public class GameController : MonoBehaviour {

	public GameManager gameManager;

	public GameObject P1;
	public GameObject P2;
	public GameObject BG;

	public Animator P1Ani;
	public Animator P2Ani;

	public Rigidbody2D P1Rigi;
	public Rigidbody2D P2Rigi;

	private MeshRenderer background;

	public Material venue;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GameObject RB;

	public Button returnButton;

	private bool gameOver;
	private bool restart;
	private int wincount;

	// Use this for initialization
	void Start () {
		GameManager gameManager = GameManager.instance;

		var tex = Resources.Load(gameManager.venue.sceneName, typeof(Texture)) as Texture;
		venue = new Material(Shader.Find ("Unlit/Texture"));
		background = BG.GetComponent<MeshRenderer> ();
		returnButton = RB.GetComponent<Button> ();
		venue.mainTexture = tex;
		background.material = venue;
		P1 = Instantiate(gameManager.playerCharacter, new Vector3(-10, 30, 0), Quaternion.identity) as GameObject;
		P2 = Instantiate(gameManager.opponentCharacter, new Vector3(10, 30, 0), Quaternion.identity) as GameObject;
		P1.tag = "Player";
		P2.tag = "Player2";
		P1Ani = P1.GetComponent<Animator> ();
	 	P2Ani = P2.GetComponent<Animator> ();
		returnButton = this.RB.GetComponent<Button> ();
		returnButton.IsActive ();

		gameOver = false;
		returnButton.gameObject.SetActive (true);
		restart = false;
		returnButton.enabled = true;
		gameOverText.text = "";
		restartText.text = "";
		wincount = gameManager.winCount;
	}

	// Update is called once per frame
	void Update () {


		if (gameOver)
		{

			restartText.text = "Press R for Restart";
			restart = true;
		}
	
	}

	public void OnClick (){

		if (returnButton.isActiveAndEnabled == true) {
			
			loadVenue ();
		}
	}

	public void GameOver() {

		gameOverText.text = "Game Over!";
		gameOver = true;
		//RB.SetActive (true);

		returnButton.gameObject.SetActive (true);
		returnButton.enabled = true;
		//loadVenue ();

		//System.Threading.Thread.Sleep(4000);
		//ScreenNavigation.LoadGameModeScreen ();
	}

	public void Win() {
		GameManager gameManager = GameManager.instance;
		gameManager.winCount++;
	}

	public void loadVenue()
	{
		ScreenNavigation.LoadGameModeScreen ();
	}
}
