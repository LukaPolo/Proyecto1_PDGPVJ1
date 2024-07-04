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

    public override void CheckHealth(){
        if(chara.Health <= 0){
            Debug.Log("has muerto");
            chara.Lifes -= 1;
            transform.position = playerSpawner;
            chara.Health = 100;
        }
        if(chara.Lifes <= 0){
            GetComponent<Collider2D>().enabled = false;
            chara.IsAlive = false;
            Destroy(gameObject);
            Debug.Log("GAME OVER");
        }
    }
}