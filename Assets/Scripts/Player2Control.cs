using UnityEngine;

public class Player2Control : MonoBehaviour
{
  #region Data
  public GameObject pong;
  private Rigidbody2D rb2d;
  public float maxSpeed;
  public float speed;
  #endregion

  /// <summary>
  /// Deals with a VERY simple "AI" created to play against the player.
  /// </summary>
  #region Events
  // On first frame.
  void Start()
  {
    rb2d = GetComponent<Rigidbody2D>();
  }

  // Compares the position of the pong with the position of the opponents paddle in order to determine
  // direction in which oppents paddle will travel to hit the pong.
  void FixedUpdate()
  {
    float pongYPos = pong.transform.position.y;

    if (pongYPos > transform.position.y)
    {
      rb2d.velocity = new Vector2(0, speed);
    }

    else
    {
      rb2d.velocity = new Vector2(0, -speed);
    }
  }
  #endregion

  /// <summary>
  /// Methods: increases oppents paddle's speed, gradually, as to increase difficult. 
  /// Velocity is capped.
  /// </summary>
  #region Helpers 
  public void IncreaseSpeed()
  {
    speed++;
    speed = Mathf.Clamp(speed, speed, maxSpeed);
  }
#endregion
}
