using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour{
    [SerializeField]private CharacterData chara;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Character"){
            other.GetComponent<Character>().TakeDamage(chara.WeaponList[chara.Weapon].AttackDamage);
            Debug.Log("hiciste " + chara.WeaponList[chara.Weapon].AttackDamage + " de danyo");
        }
    }
}   