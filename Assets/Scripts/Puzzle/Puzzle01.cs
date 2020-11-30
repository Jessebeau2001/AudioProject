using System.Collections;
using UnityEngine;

class Puzzle01 : PuzzleAbstract
{
    public AudioSource locked;
    public AudioSource unlocked;
    bool[] keyStates = new bool[3]; //should read steps int but cant cuz of some BS
    KeyCode[] keys = new KeyCode[4];
    public override int steps { get { return steps; } set { steps = 4; } } //set to one because needs to be variable for every puzzle
    [SerializeField] private int currentStep = 0;
    public GameObject door;
    public override void Start() {
        base.Start();

        keys[0] = KeyCode.R;
        keys[1] = KeyCode.D;
        keys[2] = KeyCode.F;
        keys[3] = KeyCode.G;
    }

    public override void Main()
    {
        if (currentStep >= 4) { 
            Debug.Log("Well done, you completed the pzuzzle");
            Completed();
            unlocked.Play();
            //PUZZLE COMPLETE CODE HERE
        } else if (Input.GetKeyDown(keys[currentStep])) {
            currentStep++;
            Debug.Log("Correct next should be: "  + currentStep);
            locked.Play();
        } else if (Input.anyKeyDown) {
            Debug.Log("Oops, thats a wrong one there mate should be " + currentStep + " / " + keys[currentStep]);
            currentStep = 0;
        }
    }

    public void Completed() {
        door.GetComponent<Animator>().SetBool("IsClosed", false);
        StopPuzzle();
        GameObject.Destroy(this);
    }
}