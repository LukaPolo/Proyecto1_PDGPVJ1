using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour{
    [SerializeField]private WeaponData weapon;

    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Character"){
            other.GetComponent<Character>().TakeDamage(weapon.AttackDamage);
            Debug.Log("hiciste " + weapon.AttackDamage + " de danyo");
        }
    }
}   