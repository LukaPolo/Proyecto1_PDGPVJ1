using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour{
    private Transform player;

    void OnEnable(){
        Player.lifeLose += RespawnPlayer;
    }

    void OnDisable(){
        Player.lifeLose -= RespawnPlayer;
    }

    public void RespawnPlayer(){
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        player.position = gameObject.transform.position;
        Debug.Log("HAS MUERTO");
    }
}