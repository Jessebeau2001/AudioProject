using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AAmbience : MonoBehaviour
{
    public GameObject[] soundSources;
    public float maxInterval = 20;
    public bool playAgain = true;

    /// <summary> Call this function to restart the ambience sound system if it was disabled before </summary>
    public void Start() {
        StartCoroutine(PlayNextSound(Utils.rnd.Next(5, (int) maxInterval)));
    }

    IEnumerator PlayNextSound(float delay) {
        Debug.Log("Sceduled new ambience sound to play after '" + delay + "' seconds");
        yield return new WaitForSeconds(delay);
        if (playAgain) Start();
        Main();
    }

    public virtual void Main() {
        AudioSource src = Utils.RandomArrayEntry(soundSources).GetComponent<AudioSource>();
        src.pitch = (float) Utils.RandomDouble(0.8, 1.2);
        src.Play();
    }
}
