using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBase : MonoBehaviour
{
    private GameObject player;
    private Movement pMove;
    private bool[] buttons;
    protected int steps;
    protected int currentStep = 0;
    protected virtual void Start(int steps = 0) //made like this so that inhereting class always needs to define steps
    {
        steps = this.steps;
        player = GameObject.Find("Player");
        pMove = player.GetComponent<Movement>();
    }

    protected virtual void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            currentStep++;
            if (steps >= currentStep) {
                
            }
        }
    }

    private void StartPuzzle() {
        pMove.canMove = false;
    }

    private void StopPuzzle() {
        pMove.canMove = true;
    }
}