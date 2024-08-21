//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy{
    //public static Action<AudioClip> sound;
    [SerializeField] private NPCMovement mov;
    [SerializeField] private NPCAttack attack;
    [SerializeField] private CharacterAnimation anim;
    [SerializeField] private CharacterSound sound;
    [SerializeField] private DetectionRange range, attackRange;
    [SerializeField] private Transform player;

    public override void Start(){
        base.Start();
        mov = GetComponent<NPCMovement>();
        attack = GetComponent<NPCAttack>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        sound = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<CharacterSound>();
    }

    public override void Update(){
        base.Update();
        isAlert = range.DetectCollision(enemy.DetectionRange);
        isWalking = mov.DetectMovement();
        isTurning = mov.GetDirection();
        if(isAlert && !isAttacking){
            StopCoroutine("Patrol");
            isPatrolling = false;
            mov.Move((player.position - transform.position).normalized, chara.RunSpeed);
            anim.Animate("Walk");
        }
        else if(!isPatrolling && !isAttacking){
            StartCoroutine("Patrol");
        }
        if(attackRange.DetectCollision(enemy.DetectionRange/3) && !isAttacking && !isAttackOnCooldown){
            mov.Move(Vector2.zero, 0);
            StartCoroutine(attack.Attack(this, chara.WeaponList[chara.Weapon]));
            anim.Animate("Attack");
            sound.PlaySound(chara.SoundList[1]);
        }
    }

    public IEnumerator Patrol(){
        isPatrolling = true;
        mov.Move(Vector2.zero, 0);
        anim.Animate("Idle");
        yield return new WaitForSeconds(Random.Range(1f, 3f));
        mov.Move(mov.GetRandomVector(), chara.MoveSpeed);
        anim.Animate("Walk");
        yield return new WaitForSeconds(Random.Range(0.5f, 2f));
        isPatrolling = false;
    }
}