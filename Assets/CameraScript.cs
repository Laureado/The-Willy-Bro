using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform PlayerPos;

    public float LeftLimit = 0f;
    public float RightLimit = 0f;

    Transform CameraPos;

    void Start()
    {
        CameraPos = GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if(PlayerPos.position.x > LeftLimit && PlayerPos.position.x < RightLimit)
        {
            CameraPos.position = new Vector3(PlayerPos.position.x, CameraPos.position.y, -10f);
        }
    }
}
