using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour{
    [SerializeField]private CharacterData player;
    public static Action<Vector2> direction;
    public static Action dash, attack, protect, protectRelease;
    private Vector2 moveInput;

    void Update(){
        moveInput.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        moveInput.Normalize();
        if(player.IsAlive){
            direction?.Invoke(moveInput);
            if(Input.GetButtonDown("Dash")) dash?.Invoke();
            if(Input.GetButtonDown("Attack")) attack?.Invoke();
            if(Input.GetButtonDown("Protect")) protect?.Invoke();
            if(Input.GetButtonUp("Protect")) protectRelease?.Invoke();
            //if(Input.GetButtonDown("Interact")) interact?.Invoke();
            //if(Input.GetButtonDown("Pause")) pause?.Invoke();
        }else{
            Input.ResetInputAxes();
            protectRelease?.Invoke();
        }
    }
}