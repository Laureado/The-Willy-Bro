using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftScript : MonoBehaviour
{
    public int ItemNumber = 0;
    public int ItemQuantity = 0;

    Main gm;
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameController").GetComponent<Main>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            gm.AddItemUse(ItemNumber, ItemQuantity);
            GameObject.Destroy(gameObject);
        }
    }
}
