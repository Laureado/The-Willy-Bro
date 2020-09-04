using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScript : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.D))
        {
            Anim.SetBool("isPressed", true);
            Sr.color = Color.yellow;
        }
        if(Input.GetKeyUp(KeyCode.D))
        {
            Anim.SetBool("isPressed", false);
            Sr.color = Color.white;
        }
    }
}
