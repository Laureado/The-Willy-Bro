using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstSpawnScript : MonoBehaviour
{
    public Vector2 SpawnPosition;
    void Initialize()
    {
        PlayerPrefs.SetFloat("RespawnPointX", SpawnPosition.x);
        Debug.Log("X Init: "  + SpawnPosition.x);
        PlayerPrefs.SetFloat("RespawnPointY", SpawnPosition.y);
    }
}
