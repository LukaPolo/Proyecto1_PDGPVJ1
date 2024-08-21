using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    [SerializeField]private CharacterData player;
    private Rigidbody2D physics;

    void OnEnable(){
        physics = GetComponent<Rigidbody2D>();
        PlayerInput.direction += Move;
        PlayerInput.direction += Turn;
    }

    void OnDisable(){
        PlayerInput.direction -= Move;
        PlayerInput.direction -= Turn;
    }

    public void Move(Vector2 moveInput){
        physics.velocity = moveInput * player.MoveSpeed;
        if(physics.velocity.x != 0 || physics.velocity.y != 0){
            player.IsWalking = true;
        }else{
            player.IsWalking = false;
        }
    }

    public void Turn(Vector2 moveInput){
        if(moveInput.x < 0) player.IsTurning = true;
        if(moveInput.x > 0) player.IsTurning = false;
    }


}