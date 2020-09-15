using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    Main Gm;
    public float BackForce;
    bool isDead;
    void Start()
    {
        Gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<Main>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDead)
        {
            Debug.Log("Si");
            Gm.GameOver();
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Feet"))
        {
            isDead = true;
            Debug.Log("No");
            collision.gameObject.GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * BackForce;
            Destroy(this.gameObject);
        }
    }
}
