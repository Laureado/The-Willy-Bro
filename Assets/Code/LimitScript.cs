using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitScript : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D col)
    {
        col.GetComponent<Transform>().transform.position = new Vector3(0, 5, 0);
    }
}
