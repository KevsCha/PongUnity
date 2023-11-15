using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalController : MonoBehaviour
{
    public int idGoal;
    GameController gameController;
    private void Awake()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            if (idGoal == 1)
                gameController.Player2Scored();
            if (idGoal == 2)
                gameController.Player1Scored();
        }
    }
}
