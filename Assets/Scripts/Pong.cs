using UnityEngine;

public class Pong : MonoBehaviour
{

  #region
  private Rigidbody2D rb2d;
  public GameManager manager;
  public float XSpeed;
  public float YSpeed;
  public float maxSpeed;
  #endregion Data

  /// <summary>
  /// Controls intial velocity, tells the GameManager if the pong has crossed Player 1 or Player 2's 
  /// bounds; reports a score. Creates physics for the pong to "bounce" off paddles appropriately.
  /// </summary>
  #region Events
  // On first frame
  void Start()
  {
    GetComponent<Rigidbody2D>().velocity = new Vector2(-XSpeed, YSpeed);
    rb2d = GetComponent<Rigidbody2D>();
  }

  
  // Moniters collision with box colliders in order to report score increase to GameManager.
  void OnTriggerEnter2D(Collider2D other)
  {
    // If the gameObject collides with bounds
    if (other.gameObject.CompareTag("Bound"))
    {

      ResetPong();

      // If the pong collides with Player 1 bounds increases playerTwo's score. 
      if (other.name.Equals("Player 1 Bounds"))
      {
        manager.playerTwoScored();

      }

      // If the pong collides with Player 2 bounds increase playerOne's score.
      if (other.name.Equals("Player 2 Bounds"))
      {
        manager.playerOneScored();
      }
    }
  }

  private void OnCollisionEnter2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Paddle"))
    {
      // Figure out how far up or down the ball hit the paddle.
      float offsetFromCenter = rb2d.transform.position.y - other.transform.position.y;
      float otherHeight = other.gameObject.GetComponent<Collider2D>().bounds.size.y;
      // Get the fraction from -1(bottom) to 1(top) of where the ball hit paddle.
      float fractionFromCenter = offsetFromCenter / (otherHeight / 2);

      Vector2 oldVelocity = rb2d.velocity;
      // Scale y velocity to the fraction of where we hit the paddle by the current x velocity.
      float newYVelocity = fractionFromCenter * oldVelocity.x;
      // Set the new velocity.
      rb2d.velocity = new Vector2(oldVelocity.x, newYVelocity);
    }
  }
  #endregion

  /// <summary>
  /// Methods: resets pong.
  /// </summary>
  #region Helpers 
  void ResetPong()
  {
    transform.position = new Vector3(0, 0, 0);

    XSpeed++;
    YSpeed++;

    // Puts a cap on the velocity of the pong.
    XSpeed = Mathf.Clamp(XSpeed, XSpeed, maxSpeed);
    YSpeed = Mathf.Clamp(YSpeed, XSpeed, maxSpeed);

    rb2d.velocity = new Vector2(XSpeed, YSpeed);
  }
  #endregion
}
