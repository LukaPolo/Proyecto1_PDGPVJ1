using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class Player : Character{
    private Vector3 playerSpawner;

    private void Start(){
        playerSpawner = GameObject.FindGameObjectWithTag("PlayerSpawner").transform.position;
        transform.position = playerSpawner;
        GetComponent<Collider2D>().enabled = true;
        chara.IsAlive = true;
    }

    void Update(){
        chara.IsWaiting = !(!chara.IsAlive || chara.IsWalking || chara.IsAttacking || chara.IsDashing || chara.IsProtecting);
        if(!chara.IsAttacking){
            if(chara.IsTurning){
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }else{
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    public override void CheckHealth(){
        if(chara.Health <= 0){
            chara.Lifes -= 1;
            if(chara.Lifes > 0){
                transform.position = playerSpawner;
                chara.Health = chara.MaxHealth;
                Debug.Log("has muerto");
            }else{
                GetComponent<Collider2D>().enabled = false;
                chara.IsAlive = false;
                Debug.Log("GAME OVER");
            }
        }
    }
}