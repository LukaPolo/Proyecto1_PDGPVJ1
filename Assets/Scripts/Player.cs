using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{
    [SerializeField]private float health;

    void Start(){
        health = 10;
    }
}