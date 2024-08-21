using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character{
    [SerializeField] public EnemyData enemy;
    [SerializeField] public AudioSource controlSonido;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] public int health;
    [SerializeField] public bool isAlert, isPatrolling;

    public virtual void Start(){
        health = chara.MaxHealth;
        isAlive = true;
    }

    public override void Wait(){
        isWaiting = !(!isAlive || isWalking || isAttacking);
    }

    public override void Turn(){
        if(!isAttacking){
            if(isTurning){
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }else{
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public override void CheckHealth(){
        if(health <= 0){
            isAlive = false;
            controlSonido.PlayOneShot(deathSound);
            Destroy(gameObject, enemy.WaitTime);
        }
    }

    public override void TakeDamage(int attackDamage){
        health -= attackDamage;
        CheckHealth();
    }
}