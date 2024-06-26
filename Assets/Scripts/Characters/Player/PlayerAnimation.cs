using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour{
    [SerializeField]private CharacterData player;
    [SerializeField]private SpriteRenderer sprite;
    [SerializeField]private Animator anim;

    void Update(){
        sprite.flipX = player.IsTurning;
        anim.SetBool("Walk", player.IsWalking);
    }
}