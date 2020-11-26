using UnityEngine;
using System.Collections;

public interface IPuzzle
{
    GameObject player { get; set; } //make sure everything hasa a Player variable
    int steps { set; } //make sure every inheritance has a steps integer variable

    void StartPuzzle();
    void StopPuzzle();

}