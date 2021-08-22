using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private int p1Score = 0;
    private int p2Score = 0;

    private int limitScore = 5;


    public void AddScore(PlayerNumber player)
    {
        if (player == PlayerNumber.Player1)
        {
            p1Score++;
            Debug.Log("p1 :" + p1Score);
            CheckIfWin(PlayerNumber.Player1, p1Score);
        }
        else if(player == PlayerNumber.Player2)
        {
            p2Score++;
            Debug.Log("p2 :" + p2Score);
            CheckIfWin(PlayerNumber.Player2, p2Score);
        }
    }

    private void CheckIfWin(PlayerNumber player, int score)
    {
        if (score >= limitScore)
        {
            Debug.Log(player.ToString() + " Win!!!!");
        }
    }
    
}
