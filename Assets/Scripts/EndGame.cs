using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{
    public bool endGame;
    public Animation animEndGame;
    void Start()
    {
        endGame = false;
    }
    void Update()
    {
        if(endGame == true)
        {
            animEndGame.Play("EndGame");
            endGame = false;
        }    
    }
    
}
