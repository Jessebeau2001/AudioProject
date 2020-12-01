using UnityEngine;
using System.Collections;

public interface IPuzzle
{
    GameObject player { get; } //make sure everything has a Player variable
    
    void StartPuzzle();
    void StopPuzzle();

}