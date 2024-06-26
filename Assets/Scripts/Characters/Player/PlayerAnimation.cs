using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour{
    [SerializeField]private CharacterData player;
    [SerializeField]private SpriteRenderer sprite;
    [SerializeField]private Animator anim;

    void Update(){
        sprite.flipX = player.IsTurning;
        Movement();
        Attack();
    }
    public void Attack()
    {
        anim.SetBool("isAttacking", player.IsAttacking);
        anim.SetBool("isAttackOnCooldown", player.IsAttackOnCooldown);
        anim.SetBool("isOnFire", player.IsOnFire);
        anim.SetInteger("idWeapon", player.Weapon );
    }
    public void Movement()
    {
        anim.SetBool("isWaiting", player.IsWaiting);
        anim.SetBool("isWalking", player.IsWalking);
        anim.SetBool("isDashing", player.IsDashing);
        anim.SetBool("isDashOnCooldown", player.IsDashOnCooldown);
    }
}