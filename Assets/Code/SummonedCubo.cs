using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonedCubo : MonoBehaviour
{
    SpriteRenderer Sp;
    int countTrigger = 0;
    void Start()
    {
        Sp = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Sp.color = Color.red;
        countTrigger++;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        countTrigger--;
        if(countTrigger == 0)
            Sp.color = Color.green;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            transform.parent = collision.gameObject.transform;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
            transform.parent = null;
    }

}
