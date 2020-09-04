using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial2Script : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            Anim.SetBool("isPressed", true);
            Sr.color = Color.yellow;
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            Anim.SetBool("isPressed", false);
            Sr.color = Color.white;
        }
    }
}
