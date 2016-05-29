﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class PlayerScore : MonoBehaviour {



    int p1Score = 0;
    int p2Score = 0;


    /*
     * These values will keep track of the player's score.
     * They will both be stored as an integer.
     */

    public int P1Score
    {
        get { return p1Score; }
    }

    public int P2Score
    {
        get { return p2Score; }
    }

   /*
    * We need these values for our other scripts.
    * We only change these integers in this script, 
    * so we only use a 'get'.
    */


    void Start()
    {
        HealthPlayer.OnP1Death += AddScoreP1;
        HealthPlayer.OnP2Death += AddScoreP2;
    }

    /*
     * Adding functions to the delegate located in HealthPlayer.
     */

    private void AddScoreP1(HealthPlayer player)
    {
        p1Score += player.PlayerPoint;
    }

    // Adds a point to P1.

    private void AddScoreP2(HealthPlayer player)
    {
        p2Score += player.PlayerPoint;
    }

    // Adds a point to P2.
}