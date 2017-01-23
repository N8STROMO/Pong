using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour {

	//Holding reference to playerOneScore Text and playerTwoScore Text
	public Text playerOneText;
	public Text playerTwoText;

    public GameObject pongPrefab;

    public Player2Control player2Control;

	//Created two varaibles to store player's score
	private int playerOneScore = 0; 
	private int playerTwoScore = 0;

    /// <summary>
    /// Update playerOneScore vararible and PlayerOneText text
    /// </summary>
    public void playerOneScored () 
	{
		playerOneScore++;
		playerOneText.text = playerOneScore + "";
        player2Control.IncreaseSpeed();

    }

    /// <summary>
    /// Update playerTwoScore variable and PlayerTwoText text
    /// </summary>
    public void playerTwoScored () 
	{
		playerTwoScore++;
		playerTwoText.text = playerTwoScore + "";
        player2Control.IncreaseSpeed();
	}
}
