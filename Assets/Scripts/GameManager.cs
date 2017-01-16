using System.Collections;
using System.Collections.Generic;
//Added to namespace in order to use Text class
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

	//Created method to update playerOneScore vararible and PlayerOneText text
	public void playerOneScored () 
	{
		playerOneScore++;
		playerOneText.text = playerOneScore + "";
        player2Control.IncreaseSpeed();

    }

	//Created mthod to update playerTwoScore variable and PlayerTwoText text
	public void playerTwoScored () 
	{
		playerTwoScore++;
		playerTwoText.text = playerTwoScore + "";
        player2Control.IncreaseSpeed();
	}



}
