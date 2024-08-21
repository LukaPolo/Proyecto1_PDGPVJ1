using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour{
    private Rigidbody2D physics;
    private bool isFacingLeft = false;

    void OnEnable(){
        physics = GetComponent<Rigidbody2D>();
    }

    public void Move(Vector2 moveInput, float speed){
        physics.velocity = moveInput * speed;
    }

    public bool DetectMovement(){
        if(physics.velocity.x != 0 || physics.velocity.y != 0){
            return true;
        }else{
            return false;
        }
    }

    public bool GetDirection(){
        if(physics.velocity.x < 0) isFacingLeft = true;
        if(physics.velocity.x > 0) isFacingLeft = false;
        return isFacingLeft;
    }

    public Vector2 GetRandomVector(){
        Vector2 moveInput = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        moveInput.Normalize();
        return moveInput;
    }
}