using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public AudioClip Audiocutscene1;
    public float delay = 0;
    void Start()
    {
        AudioSource.PlayClipAtPoint(Audiocutscene1, transform.position);
        StartCoroutine(EnableGame());
    }
    
    IEnumerator EnableGame() {
        yield return new WaitForSeconds(Audiocutscene1.length + delay);
        SceneManager.LoadScene(1);
        Destroy(this);
    }
}
