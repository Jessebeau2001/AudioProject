using UnityEngine;
using System.Collections;

public interface IPuzzle
{
    Collider trigger { get; }
    GameObject player { get; } //make sure everything has a Player variable
    int steps { set; } //make sure every inheritance has a steps integer variable
    
    void StartPuzzle();
    void StopPuzzle();

}