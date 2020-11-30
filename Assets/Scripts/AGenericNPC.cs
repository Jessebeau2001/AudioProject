using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract class AGenericNPC : MonoBehaviour
{
    public bool singleUse = false;
    public AudioClip audioQueue;
    public KeyCode interactionKey = KeyCode.Space; //can be overriden if needed
    [SerializeField] private bool _playerInTrigger = false;
    public bool playerInTrigger { get { return _playerInTrigger; } set { _playerInTrigger = value; }}

    public virtual void Update() {
        if (Input.GetKeyDown(interactionKey) && playerInTrigger) {
            Main();
            if (singleUse)
                this.enabled = false;
        }

    }

    public virtual void Main() {
        AudioSource.PlayClipAtPoint(audioQueue, transform.position);
    }

    private void OnTriggerEnter() {
        playerInTrigger = true;
    }

    private void OnTriggerExit() {
        playerInTrigger = false;
    }
}
