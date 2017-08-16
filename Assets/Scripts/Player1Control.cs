using UnityEngine;

public class Player1Control : MonoBehaviour {

  #region Data
  public Rigidbody2D rb2d;
	public float speed;
  #endregion

  /// <summary>
  /// On every physics itteration. Deals with controlling the paddle using arrow keys.
  /// </summary>
  #region Events
  // On initialization.
  private void Start() 
	{
		rb2d = GetComponent<Rigidbody2D> ();	
	}

  // On every physics itteration.
  private void FixedUpdate()
	{
		// Created two boolean variables to determine if up or down arrow is pressed.
		bool movementUp = Input.GetKey (KeyCode.UpArrow);
		bool movementDown = Input.GetKey (KeyCode.DownArrow);
	
		// Controls the movemnt based on which arrow key is selected. 
		// Instantiated new Vector2 class taking x and y arguments (paddle speed) within each branch.
		// of conidtional statement to control movement. First argument is 0; the paddle does not move in the x direction
		// playerOne sprite does not move horizontally.
		if (movementUp) 
		{
			rb2d.velocity = new Vector2 (0, speed);
		} 

		else if (movementDown) 
		{
			rb2d.velocity = new Vector2 (0, -speed);
		
		} 

		// Default condition needed in case neither arrow key is being pressed.
		else 
		{
			rb2d.velocity = Vector2.zero;
		}
	}
  #endregion
}


