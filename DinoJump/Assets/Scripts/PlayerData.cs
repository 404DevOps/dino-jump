using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public string Name { get; set; }
    public Color Color { get; set; }

    public PlayerState playerState {get;set;}
}

public enum PlayerState
{ 
    NotReady, Ready, Alive, Dead
}
