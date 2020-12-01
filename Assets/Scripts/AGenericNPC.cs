using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class AGenericNPC : MonoBehaviour, IInteractable
{
    public bool singleUse = false;
    public AudioClip audioQueue;
    public virtual void Interact() {
        AudioSource.PlayClipAtPoint(audioQueue, transform.position);
        if (singleUse)
            this.enabled = false;
    }
}
