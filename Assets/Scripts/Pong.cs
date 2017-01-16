using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : MonoBehaviour {
    Random number = new Random();

    public float maxSpeed;

    private Rigidbody2D rb2d;
    
    //Give access to GameManager class
    public GameManager manager;

    public Player1Control player1;
    public Player2Control player2;

    //Create varaible to control speed
    public float initialXSpeed;
    public float initialYSpeed;
    private object rb2b;

    //Creates behavior of pong on start. Instantiated new Vector 2 to control intial 
    //speed of pong. Could this be "void Start()"?
    void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-initialXSpeed, initialYSpeed);
        rb2d = GetComponent<Rigidbody2D>();
    }

    //private void OnTriggerEnter()
    // {
    //     rb2d.velocity = Vector3.Reflect(-rb2d.velocity, this.transform.forward);
    //
    // }

    //Moniters collision with box colliders in order to report score increase to GameManager
    void OnTriggerEnter2D(Collider2D other)
    {

        //If the gameObject intidenfied with tag collides with bounds
        if (other.gameObject.CompareTag("Bound"))
        {

            ResetPong();

            //If the pong collides with Player 1 bounds tell GameManager to execute method:
            //playerTwoScored()
            if (other.name.Equals("Player 1 Bounds"))
            {
                manager.playerTwoScored();

            }

            //If the pong collides with Player 2 bounds tell GameManager to execute method:
            //playerOneScored()
            if (other.name.Equals("Player 2 Bounds"))
            {
                manager.playerOneScored();
            }

        }
    }


    void ResetPong() 
     {
        transform.position = new Vector3(0, 0, 0);

        initialXSpeed++;
        initialYSpeed++;
        initialXSpeed = Mathf.Clamp(initialXSpeed, initialXSpeed, maxSpeed);
        initialYSpeed = Mathf.Clamp(initialYSpeed, initialXSpeed, maxSpeed);

        rb2d.velocity = new Vector2(initialXSpeed, initialYSpeed);

    }
}
