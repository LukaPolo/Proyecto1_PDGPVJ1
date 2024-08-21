using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAttack : MonoBehaviour{
    [SerializeField]private Transform hitboxField;
    [SerializeField]private GameObject hitbox;
    [SerializeField]private float start;
    [SerializeField]private float finish;
    [SerializeField]private float attackProgress;

    void OnEnable(){
        attackProgress = 0f;
    }

    public IEnumerator Attack(Character chara, WeaponData weapon){
        chara.isAttacking = true;
        hitbox = Instantiate(weapon.Hitbox, hitboxField);
        start = weapon.HitboxStart;
        finish = weapon.HitboxFinish;
        while(attackProgress < 1){
            attackProgress += weapon.AttackSpeed * Time.deltaTime;
            hitbox.transform.localRotation = Quaternion.Euler(0, 0, Mathf.Lerp(start, finish, attackProgress));
            yield return null;
        }
        yield return new WaitForSeconds(weapon.AttackDuration);
        Destroy(hitbox);
        chara.isAttacking = false;
        chara.isAttackOnCooldown = true;
        yield return new WaitForSeconds(weapon.AttackCooldown);
        attackProgress = 0f;
        chara.isAttackOnCooldown = false;
    }
}