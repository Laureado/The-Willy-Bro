using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial3Script : MonoBehaviour
{
    Animator Anim;
    SpriteRenderer Sr;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Anim.SetBool("isPressed", true);
            Sr.color = Color.yellow;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Anim.SetBool("isPressed", false);
            Sr.color = Color.white;
        }
    }
}
