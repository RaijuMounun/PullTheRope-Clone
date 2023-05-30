using System;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public int pullPower;
    public Vector2 rangeDelayAI;

    private void Awake()
    {
        if(Instance == null) Instance = this;
    }
}
