using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Room1NPC : AGenericNPC
{
    public AudioSource preDialogue;
    public AudioSource mainDialogue;
    public bool isCallingOut = true;
    private GameObject puzzle;
    private void Start() {
        try {
            puzzle = GameObject.Find("DoorMechanism");
            puzzle.GetComponent<Puzzle01>().enabled = false;
        } catch (Exception) {
            throw new Exception("Puzzle01 GameObject could not be found");
        }

    }

    //https://stackoverflow.com/questions/10781993/c-sharp-complete-return-from-base-method
    public override void Interact() {
        base.Interact();
        mainDialogue.Play();
        Destroy(preDialogue.gameObject);
        StartCoroutine(EnablePuzzle());
    }

    IEnumerator EnablePuzzle() {
        Debug.Log("Started co-routine for: " + mainDialogue.clip.length + " Seconds");
        yield return new WaitForSeconds(mainDialogue.clip.length);
        // yield return new WaitForSeconds(2); //set to to secs for debug
        Debug.Log("Enabled Puzzle");
        puzzle.GetComponent<Puzzle01>().enabled = true;
        puzzle.GetComponent<Puzzle01>().afterCutscene = true;
    }
}
