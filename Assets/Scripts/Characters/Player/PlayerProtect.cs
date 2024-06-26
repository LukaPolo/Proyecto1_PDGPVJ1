using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProtect : MonoBehaviour{
    [SerializeField]private CharacterData player;
    [SerializeField]private GameObject shield;

    void Start(){
        PlayerInput.protect += Protect;
    }

    void Protect(bool button){
        if(button){
            player.IsProtecting = true;
            shield.SetActive(true);
        }else{
            player.IsProtecting = false;
            shield.SetActive(false);
        }
    }
}