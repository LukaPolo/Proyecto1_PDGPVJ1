using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Player Weapon Data", menuName = "Player Weapon Data")]
public class WeaponData : ScriptableObject{
    [SerializeField]private int attackDamage;
    [SerializeField]private float attackSpeed;
    [SerializeField]private float attackDuration;
    [SerializeField]private float attackCooldown;
    [SerializeField]private bool isOnFire;

    public int AttackDamage {get {return attackDamage;} set {attackDamage = value;}}
    public float AttackSpeed {get {return attackSpeed;} set {attackSpeed = value;}}
    public float AttackDuration {get {return attackDuration;} set {attackDuration = value;}}
    public float AttackCooldown {get {return attackCooldown;} set {attackCooldown = value;}}
    public bool IsOnFire {get {return isOnFire;} set {isOnFire = value;}}
}