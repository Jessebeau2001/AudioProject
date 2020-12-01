using System.Collections;
using UnityEngine;

class Puzzle01 : PuzzleAbstract
{
    public AudioSource stepSound;
    public AudioSource unlockDoorSound;
    public AudioSource resetSound;
    public AudioClip doorDialogue_BeforeTalkscene;
    private bool firstInteract = true;
    public bool afterCutscene = false;
    bool[] keyStates = new bool[3]; //should read steps int but cant cuz of some BS
    KeyCode[] keys = new KeyCode[4];
    private int currentStep = 0;
    public GameObject doorAnimator;
    public override void Start() {
        base.Start();

        keys[0] = KeyCode.F;
        keys[1] = KeyCode.G;
        keys[2] = KeyCode.D;
        keys[3] = KeyCode.R;
    }

    public override void Main()
    {
        if (currentStep >= 4) { 
            Debug.Log("Well done, you completed the pzuzzle");
            Completed();
            unlockDoorSound.Play();
            //PUZZLE COMPLETE CODE HERE
        } else if (Input.GetKeyDown(keys[currentStep])) {
            currentStep++;
            Debug.Log("Correct next should be: "  + currentStep);
            stepSound.Play();
        } else if (Input.anyKeyDown) {
            Debug.Log("Oops, thats a wrong one there mate should be " + currentStep + " / " + keys[currentStep]);
            resetSound.Play();
            currentStep = 0;
        }
    }

    public override void OnTriggerEnter(Collider col) {
        if (afterCutscene) {
            base.OnTriggerEnter(col);
            return;
        }

        if (!firstInteract) return;
        firstInteract = false;
        AudioSource.PlayClipAtPoint(doorDialogue_BeforeTalkscene, transform.position);
    }

    public void Completed() {
        doorAnimator.GetComponent<Animator>().SetBool("IsClosed", false);
        StopPuzzle();
        GameObject.Destroy(this);
    }
}