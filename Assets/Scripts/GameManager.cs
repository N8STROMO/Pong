using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour {

  #region Data
  public Player2Control player2Control;
  public GameObject pongPrefab;
  public Text playerOneText;
	public Text playerTwoText;
  private int playerOneScore = 0; 
	private int playerTwoScore = 0;
  #endregion

  /// <summary>
  /// Update playerOneScore when playerTwo scores and update PlayerOneText text
  /// and vice versa.
  /// </summary>
  #region Events
  public void playerOneScored () 
	{
		playerOneScore++;
		playerOneText.text = playerOneScore + "";
        player2Control.IncreaseSpeed();

  }

  public void playerTwoScored () 
	{
		playerTwoScore++;
		playerTwoText.text = playerTwoScore + "";
    player2Control.IncreaseSpeed();
	}
  #endregion
}
