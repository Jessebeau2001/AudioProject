using System.Collections;
using UnityEngine;

//After further experimenting, I don't even think we need an Interface for this puzzle abstract
[RequireComponent(typeof(Collider))]
abstract class PuzzleAbstract : MonoBehaviour, IPuzzle, IInteractable
{
    public AudioClip audioQueue;
    public AudioClip audioQueueExit;
    public bool inProgress = false;
    private GameObject _player;  //Singletons????? example in Keep
    public GameObject player { get { return _player; } private set { _player = value; }}
    // player initialized here because is the same for every class that inherents from this

    private bool hasInteracted = false;
    public virtual void Start() {
        //player = GameObject.Find("Player"); ||| this code was here but moved to Awake
    }

    public void Awake() {
        player = GameObject.Find("Player");
    }

    void Update() {
        if (inProgress)
            Main();
    }

    public abstract void Main();

    public virtual void Interact() {
        if (hasInteracted) return;
        hasInteracted = true;
        StartPuzzle();
    }
    
    public virtual void StartPuzzle() {
        _player.GetComponent<Movement>().canMove = false; //should I use private or public player?
        inProgress = true;
    }

    public void StopPuzzle() {
        _player.GetComponent<Movement>().canMove = true;
        inProgress = false;
    }
    public virtual void OnTriggerEnter(Collider col) {
        AudioSource.PlayClipAtPoint(audioQueue, transform.position);
    }

    public virtual void OnTriggerExit(Collider col) {
        AudioSource.PlayClipAtPoint(audioQueueExit, transform.position);
    }
}