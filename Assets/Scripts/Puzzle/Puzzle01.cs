using System.Collections;
using UnityEngine;

class Puzzle01 : PuzzleAbstract
{
    public AudioClip doorDialogue_BeforeTalkscene;
    public AudioClip puzzleExplaination;
    public AudioClip[] failDialogue;
    private bool firstInteract = true;
    public bool afterCutscene = false;
    KeyCode[] keys = new KeyCode[4];
    public AudioClip[] keySounds = new AudioClip[4];
    private int currentStep = 0;
    private int mistakeIndex = 0;
    public int maxMistakes = 4;
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
        if (Input.anyKeyDown) {
            KeyChecker();
        }
    }

    void KeyChecker() {
        KeyCode pressedKey;

        for (int i = 0; i < keys.Length; i++) {
            if (Input.GetKeyDown(keys[i])) {
                pressedKey = keys[i];
                AudioSource.PlayClipAtPoint(keySounds[i], player.transform.position);
                
                if (pressedKey == keys[currentStep]) {
                    Debug.Log("Correct key pressed");
                    currentStep++;
                } else {
                    Debug.Log("Mistakes have been made");
                    MakeMistake();
                }

                if (currentStep >= 4){
                    Debug.Log("Puzzle Complete");
                    Completed();
                }
            }
        }
    }

    public override void OnTriggerEnter(Collider col) {
        if (afterCutscene) {
            base.OnTriggerEnter(col);
            return;
        }

        if (!firstInteract) return;
        firstInteract = false;
        AudioSource src = player.AddComponent(typeof(AudioSource)) as AudioSource;
        src.clip = doorDialogue_BeforeTalkscene;
        src.Play();
    }

    public void Completed() {
        doorAnimator.GetComponent<Animator>().SetBool("IsClosed", false);
        StopPuzzle();
        GameObject.Destroy(this);
    }

    private void MakeMistake() {
        AudioClip src = Utils.RandomArrayEntry(failDialogue);
        currentStep = 0;
        
        mistakeIndex++;
        if (mistakeIndex >= maxMistakes) {
            inProgress = false;
            mistakeIndex = 0;
            AudioSource.PlayClipAtPoint(src, player.transform.position);
            StartCoroutine(StartKeyDetection(src.length));
        }
    }

    public override void StartPuzzle()
    {
        base.StartPuzzle();
        inProgress = false;
        AudioSource.PlayClipAtPoint(puzzleExplaination, player.transform.position);
        StartCoroutine(StartKeyDetection(puzzleExplaination.length));
    }

    IEnumerator StartKeyDetection(float delay) {
        yield return new WaitForSeconds(delay);
        inProgress = true;
    }
}