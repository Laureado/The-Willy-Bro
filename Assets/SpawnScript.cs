using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    Main GameMaster;

    GameObject CameraObject;
    Transform CameraPosition;
    Camera Camera;

    Transform CPosition;

    public Vector2 NewCameraPosition;
    public float NewCameraSize = 0f;
    void Start()
    {
        GameMaster = GameObject.FindGameObjectWithTag("GameController").GetComponent<Main>();
        CameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        CameraPosition = CameraObject.GetComponent<Transform>();
        Camera = CameraObject.GetComponent<Camera>();
        CPosition = GetComponent<Transform>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player"){
            CameraPosition.position = new Vector3(NewCameraPosition.x, NewCameraPosition.y, -10f);
            GameMaster.SetSpawnPosition(new Vector3(CPosition.position.x, CPosition.position.y, 0f));
            if (NewCameraSize != 0)
            {
                Camera.orthographicSize = NewCameraSize;
            }
        }
    }
}
