using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeakScript : MonoBehaviour
{
    public GameObject Enemy;
    public float BackForce;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("no");
            Destroy(Enemy);
            collision.GetComponent<Rigidbody2D>().velocity = Vector2.up * BackForce;
        }
    }
}
