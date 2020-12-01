﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
class Room1NPC : AGenericNPC
{
    public AudioSource preDialogue;
    private AudioSource mainDialogue;
    public bool isCallingOut = true;
    private GameObject puzzle;
    private void Start() {
        mainDialogue = GetComponent<AudioSource>();

        try {
            puzzle = GameObject.Find("DoorMechanism");
            puzzle.GetComponent<Puzzle01>().enabled = false;
        } catch (Exception) {
            throw new Exception("Puzzle01 GameObject could not be found");
        }

    }

    public void Update() {
        if (isCallingOut) {
            //calling out code (Something like a playback of the same file with random intervals in between)
        }
    }

    public override void Interact() {
        base.Interact();
        mainDialogue.Play();
        StartCoroutine(EnablePuzzle());
    }

    IEnumerator EnablePuzzle() {
        Debug.Log("Started co-routine for: " + mainDialogue.clip.length + " Seconds");
        // yield return new WaitForSeconds(mainDialogue.clip.length);
        yield return new WaitForSeconds(2); //set to to secs for debug
        Debug.Log("Enabled Puzzle");
        puzzle.GetComponent<Puzzle01>().enabled = true;
        puzzle.GetComponent<Puzzle01>().afterCutscene = true;
    }
}
