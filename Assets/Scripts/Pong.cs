using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : MonoBehaviour {

    public float maxSpeed;

    private Rigidbody2D rb2d;
    
    //Give access to GameManager class
    public GameManager manager;

    //Create varaible to control speed
    public float initialXSpeed;
    public float initialYSpeed;

    //Creates behavior of pong on start. Instantiated new Vector 2 to control intial 
    //speed of pong. Could this be "void Start()"?
    void Awake()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(-initialXSpeed, initialYSpeed);
        rb2d = GetComponent<Rigidbody2D>();
    }

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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Paddle"))
        {
            // Figure out how far up or down the ball hit the paddle
            float offsetFromCenter = rb2d.transform.position.y - other.transform.position.y;
            float otherHeight = other.gameObject.GetComponent<Collider2D>().bounds.size.y;
            // Get the fraction from -1(bottom) to 1(top) of where the ball hit paddle 
            float fractionFromCenter = offsetFromCenter / (otherHeight / 2);
            
            Vector2 oldVelocity = rb2d.velocity;
            // Scale y velocity to the fraction of where we hit the paddle by the current x velocity
            float newYVelocity = fractionFromCenter * oldVelocity.x;
            // Set the new velocity
            rb2d.velocity = new Vector2(oldVelocity.x, newYVelocity);
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
