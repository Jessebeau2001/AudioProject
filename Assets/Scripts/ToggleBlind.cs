using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class ToggleBlind : MonoBehaviour
{
    private Image blackbox;
    public bool isBlind = false;
    void Start()
    {
        blackbox = GetComponent<Image>();
        blackbox.enabled = isBlind;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) {
            isBlind = !isBlind;
            blackbox.enabled = isBlind;
        }
    }
}
