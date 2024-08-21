using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character{
    public static Action lifeLose, death;
    [SerializeField] public bool isDashing, isDashOnCooldown, isProtecting;

    public void Start(){
        chara.Health = chara.MaxHealth;
        chara.IsAlive = true;
        GetComponent<Collider2D>().enabled = true;
    }

    public override void Wait(){
        chara.IsWaiting = !(!chara.IsAlive || chara.IsWalking || chara.IsAttacking || chara.IsDashing || chara.IsProtecting);
    }

    public override void Turn(){
        if(!chara.IsAttacking){
            if(chara.IsTurning){
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }else{
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public override void CheckHealth(){
        if(chara.Health <= 0){
            chara.Lifes -= 1;
            if(chara.Lifes > 0){
                chara.Health = chara.MaxHealth;
                lifeLose?.Invoke();
            }else{
                GetComponent<Collider2D>().enabled = false;
                chara.IsAlive = false;
                death?.Invoke();
                Debug.Log("GAME OVER");
            }
        }
    }

    public override void TakeDamage(int attackDamage){
        chara.Health -= attackDamage;
        CheckHealth();
    }
}