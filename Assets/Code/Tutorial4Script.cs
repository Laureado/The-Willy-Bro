using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial4Script : MonoBehaviour
{
    Animator Anim;
    SpriteRenderer Sr;

    bool OneIsPressed = false;

    public SpriteRenderer ArrowSr;
    public Animator ArrowAnim;
    void Start()
    {
        Anim = GetComponent<Animator>();
        Sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(OneIsPressed == false){
                OneIsPressed = true;
                Anim.SetBool("1IsPressed", OneIsPressed);
                ArrowAnim.SetBool("1IsPressed", OneIsPressed);
            }
            else
            {
                EndTutorial();
            }
        }

        if (Input.GetMouseButtonDown(0))
        {
            EndTutorial();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Anim.SetBool("ClickIsPressed", false);
            ArrowAnim.SetBool("ClickIsPressed", false);
        }
    }

    void EndTutorial()
    {
        Anim.SetBool("ClickIsPressed", true);
        ArrowAnim.SetBool("ClickIsPressed", true);
        Sr.color = Color.yellow;
    }
}
