using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour{
    [SerializeField] public CharacterData chara;
    [SerializeField] public bool isAlive, isWaiting, isWalking, isTurning, isAttacking, isAttackOnCooldown;

    public virtual void Update(){
        Wait();
        Turn();
    }

    public abstract void Wait();
    public abstract void Turn();
    public abstract void CheckHealth();
    public abstract void TakeDamage(int attackDamage);
}