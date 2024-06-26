using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character{
    public override void CheckHealth(){
        if(chara.Health <= 0){
            Destroy(gameObject);
        }
    }
}