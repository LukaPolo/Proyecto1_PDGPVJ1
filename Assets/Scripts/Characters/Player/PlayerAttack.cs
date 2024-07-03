using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{
    [SerializeField]private CharacterData player;
    [SerializeField]private Transform hitboxField;
    [SerializeField]private GameObject hitbox;
    [SerializeField]private Quaternion start;
    [SerializeField]private Quaternion finish;
    [SerializeField]private float attackProgress;

    void Start(){
        PlayerInput.attack += Attack;
        attackProgress = 0f;
    }

    void Attack(){
        if(!player.IsAttacking && !player.IsAttackOnCooldown){
            player.IsAttacking = true;
            if(player.IsTurning){
                hitboxField.localPosition = new Vector2(0.36f, 0);
                hitboxField.localRotation = Quaternion.Euler(0, 180, 0);
            }else{
                hitboxField.localPosition = new Vector2(0, 0);
                hitboxField.localRotation = Quaternion.Euler(0, 0, 0);
            }
            StartCoroutine(Attack1());
        }
    }

    IEnumerator Attack1(){
        hitbox = Instantiate(player.WeaponList[player.Weapon].Hitbox, hitboxField);
        start = Quaternion.Euler(0, 0, player.WeaponList[player.Weapon].HitboxStart);
        finish = Quaternion.Euler(0, 0, player.WeaponList[player.Weapon].HitboxFinish);
        while(attackProgress < 1){
            attackProgress += player.WeaponList[player.Weapon].AttackSpeed * Time.deltaTime;
            hitbox.transform.localRotation = Quaternion.Slerp(start, finish, attackProgress);
            yield return null;
        }
        yield return new WaitForSeconds(player.WeaponList[player.Weapon].AttackDuration);
        Destroy(hitbox);
        player.IsAttacking = false;
        player.IsAttackOnCooldown = true;
        yield return new WaitForSeconds(player.WeaponList[player.Weapon].AttackCooldown);
        attackProgress = 0f;
        player.IsAttackOnCooldown = false;
    }
}