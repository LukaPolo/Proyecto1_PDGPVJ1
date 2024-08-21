using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : Enemy{
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
            StopCoroutine("Patrol");
            isPatrolling = false;
            mov.Move((player.position - transform.position).normalized, chara.RunSpeed);
        }
        else if(!isPatrolling){
            StartCoroutine("Patrol");
        }
        if(attackRange.DetectCollision(enemy.DetectionRange/3) && !isAttacking && !isAttackOnCooldown){
            StartCoroutine(attack.Attack(this, chara.WeaponList[chara.Weapon]));
        }
    }

    public IEnumerator Patrol(){
        isPatrolling = true;
        mov.Move(Vector2.zero, 0);
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        mov.Move(mov.GetRandomVector(), chara.MoveSpeed);
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        isPatrolling = false;
    }
}