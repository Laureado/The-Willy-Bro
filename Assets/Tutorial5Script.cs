using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial5Script : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GetComponent<SpriteRenderer>().enabled = true;
    }
}
