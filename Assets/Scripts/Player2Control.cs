using UnityEngine;

public class Player2Control : MonoBehaviour {

    public GameObject pong;
    public float maxSpeed;
    public float speed;
    private Rigidbody2D rb2d;
    
    /// <summary>
    /// On first frame
    /// </summary>
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Compares the position of the pong with the position of the opponents paddle
    /// A basic AI
    /// </summary>
    void Update () {
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

    /// <summary>
    /// 
    /// </summary>
    public void IncreaseSpeed()
    {
        speed++;
        speed = Mathf.Clamp(speed, 5, maxSpeed);
    } 
}
