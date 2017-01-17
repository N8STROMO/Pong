using UnityEngine;

public class Player1Control : MonoBehaviour {

	//Created Rigidbody2D varible to control the playerOne sprite  
	Rigidbody2D rb2d;

	//Created variable to control speed
	public float speed;

	//Creates pong on start of game 
	void Start() 
	{
		rb2d = GetComponent<Rigidbody2D> ();	
	}

	//Updates with every new physics iteration 
	void FixedUpdate()
	{
		//Created two boolean variables to determine if up or down arrow is pressed
		bool movementUp = Input.GetKey (KeyCode.UpArrow);
		bool movementDown = Input.GetKey (KeyCode.DownArrow);

	
		//Controls the movemnt based on which arrow key is selected 
		//Instantiated new Vector2 class taking x and y arguments within each branch
		//of conidtional statement to control movement. First argument is 0; 
		//playerOne sprite does not move horizontally
		if (movementUp) 
		{
			rb2d.velocity = new Vector2 (0, speed);
		} 

		else if (movementDown) 
		{
			rb2d.velocity = new Vector2 (0, -speed);
		
		} 

		//Default condition needed in case neither arrow key is being pressed
		else 
		{
			rb2d.velocity = Vector2.zero;
		}
	}

}
