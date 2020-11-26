using System.Collections;
using UnityEngine;

//After further experimenting, I don't even think we need an Interface for this puzzle abstract
abstract class PuzzleAbstract : MonoBehaviour, IPuzzle
{
    //vvv Singletons????? example in Keep
    private GameObject _player;
    public GameObject player 
    { // Gets initialized here because is the same for every class that inherents from this
        get { return _player; }
        set { _player = GameObject.Find("Player"); }
    }
    public abstract int steps { set; } //is dupilcate cuz needs to be changed in main class

    private void Start() {

    }

    public void StartPuzzle() {
        _player.GetComponent<Movement>().canMove = false; //should I use private or public player?
    }

    public void StopPuzzle() {
        _player.GetComponent<Movement>().canMove = true;
    }
}