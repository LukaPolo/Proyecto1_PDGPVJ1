using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour{
    public delegate void DirectionalInput(float xAxis, float yAxis);
    public static DirectionalInput directionalInput;

    void Update(){
        directionalInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}