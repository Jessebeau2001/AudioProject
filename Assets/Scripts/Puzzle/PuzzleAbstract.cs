using System.Collections;
using UnityEngine;

//After further experimenting, I don't even think we need an Interface for this puzzle abstract
[RequireComponent(typeof(Collider))]
abstract class PuzzleAbstract : MonoBehaviour, IPuzzle
{
    private bool inProgress = false;
    private bool playerInTrigger = false;
    private Collider _trigger;
    public Collider trigger { get { return _trigger; } private set { _trigger = value; }}
    private GameObject _player;  //Singletons????? example in Keep
    public GameObject player { get { return _player; } private set { _player = value; }}
    // player initialized here because is the same for every class that inherents from this
    public abstract int steps { get; set; }
    //int steps is dupilcate cuz needs to be changed in main class

    public virtual void Start() {
        Debug.Log("Puzzle has started");
        player = GameObject.Find("Player");
        trigger = GetComponent<Collider>();
    }

    void Update() {
        if (Input.GetKey(KeyCode.Space) && playerInTrigger == true) {
            StartPuzzle();
        }

        if (inProgress)
            Main();
    }

    public abstract void Main();

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Player") {
            playerInTrigger = true;
        }
    }

    void OnTriggerExit(Collider col) {
        if (col.tag == "Player") {
            playerInTrigger = false;
        }
    }

    public void StartPuzzle() {
        _player.GetComponent<Movement>().canMove = false; //should I use private or public player?
        inProgress = true;
    }

    public void StopPuzzle() {
        _player.GetComponent<Movement>().canMove = true;
        inProgress = false;
    }
}