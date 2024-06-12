using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{
    [SerializeField]private float speed = 5;

    void Start(){
        PlayerInput.directionalInput += Move;
    }

    void Move(float xAxis, float yAxis){
        transform.Translate(new Vector2(xAxis, yAxis).normalized * speed * Time.deltaTime);
    }
}