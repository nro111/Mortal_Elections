using UnityEngine;
using System.Collections;
using Assets;

public class PlayerMovement : MonoBehaviour, IMovable {

    private float moveX;
    private float moveY; 
    public float moveSpeed;
    private Rigidbody2D player;
    private bool facingRight = true;
	public static string simulatedButton;

    // Use this for initialization
    void Start()
    {
        player = GetComponent<Rigidbody2D>();        
    }
    void FixedUpdate () {
        Move();        
    }

    public void Flip()
    {
        facingRight = !facingRight;
        Vector3 spriteScale = transform.localScale; //sets spriteScale equal to the current local scale of the sprite
        spriteScale *= -1; //flips the spriteScale 
        transform.localScale = spriteScale; 
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            
        }
		else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || simulatedButton == "Left")
        {
            float move = Input.GetAxis("Horizontal");
           

            player.velocity = new Vector2(move * moveSpeed, 0);
            player.AddForce(Vector2.left * 20);
        }
		else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || simulatedButton == "Right")
        {
            float move = Input.GetAxis("Horizontal");
            
            player.velocity = new Vector2(move * moveSpeed, 0);
            player.AddForce(Vector2.right * 20);
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            

        }
        else {
            player.velocity = Vector2.zero;
        }
        
        player.velocity = Vector2.ClampMagnitude(player.velocity, moveSpeed);
    }
}
