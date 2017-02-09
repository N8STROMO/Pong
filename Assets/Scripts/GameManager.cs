using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour {

	public Player2Control player2Control;
    public GameObject pongPrefab;
    public Text playerOneText;
	public Text playerTwoText;
    private int playerOneScore = 0; 
	private int playerTwoScore = 0;
    

    /// <summary>
    /// Update playerOneScore when playerTwo scores and update PlayerOneText text
    /// </summary>
    public void playerOneScored () 
	{
		playerOneScore++;
		playerOneText.text = playerOneScore + "";
        player2Control.IncreaseSpeed();

    }

    /// <summary>
    /// Update playerTwoScore when playerOne scores and update PlayerTwoText text
    /// </summary>
    public void playerTwoScored () 
	{
		playerTwoScore++;
		playerTwoText.text = playerTwoScore + "";
        player2Control.IncreaseSpeed();
	}
}
