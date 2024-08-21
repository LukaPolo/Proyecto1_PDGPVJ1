using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sprout : Enemy{
    [SerializeField] private NPCMovement mov;
    [SerializeField] private NPCAttack attack;
    [SerializeField] private DetectionRange range, attackRange;
    [SerializeField] private Transform player;

    void Start(){
        mov = GetComponent<NPCMovement>();
        attack = GetComponent<NPCAttack>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update(){
        isAlert = range.DetectCollision(enemy.DetectionRange);
        if(isAlert && !isAttacking){
            mov.Move((player.position - transform.position).normalized, chara.RunSpeed);
        }else{
            mov.Move(Vector2.zero, 0);
        }
        if(attackRange.DetectCollision(enemy.DetectionRange/3) && !isAttacking && !isAttackOnCooldown){
            StartCoroutine(attack.Attack(this, chara.WeaponList[chara.Weapon]));
        }
    }
}