using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour
{
    SpriteRenderer srender;
    Animator anim;

    void Start()
    {
        srender = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    public void FlipCharacterSprite(bool isLookingLeft)
    {
        srender.flipX = isLookingLeft;
    }

    public void SetCharacterWalk(bool isMoving)
    {
        anim.SetBool("isWalking", isMoving);
    }

    public void AnimateJump()
    {
        anim.SetTrigger("takeOf");
    }

    public void SetCharacterJump(bool isInAir)
    {
        anim.SetBool("isJumping", isInAir);
    }

}
