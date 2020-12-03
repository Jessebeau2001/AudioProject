using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class AGenericNPC : MonoBehaviour, IInteractable
{
    public bool singleUse = false;
    public AudioClip audioQueue;
    public AudioClip audioQueueExit;
    public virtual void Interact() {
        if (singleUse)
            this.enabled = false;
    }

    void OnTriggerEnter() {
        if (!this.enabled) return;
        AudioSource.PlayClipAtPoint(audioQueue, transform.position);
    }

    void OnTriggerExit() {
        if (!this.enabled) return;
        AudioSource.PlayClipAtPoint(audioQueueExit, transform.position);
    }
}
