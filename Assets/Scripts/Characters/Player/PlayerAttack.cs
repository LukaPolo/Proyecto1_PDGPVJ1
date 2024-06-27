using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{
    [SerializeField]private CharacterData player;
    [SerializeField]private GameObject activeHitbox;
    [SerializeField]private Transform hitbox;
    [SerializeField]private Transform start;
    [SerializeField]private Transform finish;
    [SerializeField]private float attackProgress;

    void Start(){
        PlayerInput.attack += Attack;
        attackProgress = 0f;
    }

    void Attack(){
        if(!player.IsAttacking){
            player.IsAttacking = true;
            StartCoroutine(Attack1());
        }
    }

    IEnumerator Attack1(){
        activeHitbox.SetActive(true);
        while(attackProgress < 1){
            attackProgress += player.WeaponList[player.Weapon].AttackSpeed * Time.deltaTime;
            hitbox.rotation = Quaternion.Slerp(start.rotation, finish.rotation, attackProgress);
            
            yield return null;
        }
        yield return new WaitForSeconds(player.WeaponList[player.Weapon].AttackDuration);
        activeHitbox.SetActive(false);
        hitbox.rotation = start.rotation;
        player.IsAttackOnCooldown = true;

        yield return new WaitForSeconds(player.WeaponList[player.Weapon].AttackCooldown);
        attackProgress = 0f;
        player.IsAttacking = false;
        player.IsAttackOnCooldown = false;
    }
}