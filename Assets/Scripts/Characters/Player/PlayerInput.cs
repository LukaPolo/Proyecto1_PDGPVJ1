using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour{
    public delegate void DirectionalInput(float xAxis, float yAxis);
    public delegate void AttackInput(bool button);
    public delegate void DashInput(bool button);
    public delegate void ProtectInput(bool button);
    public delegate void InteractInput(bool button);
    public static DirectionalInput directionalInput;
    public static AttackInput attackInput;
    public static DashInput dashInput;
    public static ProtectInput protectInput;
    public static InteractInput interactInput;

    void Update(){
        directionalInput(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        attackInput(Input.GetButton("Attack"));
        dashInput(Input.GetButton("Dash"));
        protectInput(Input.GetButton("Protect"));
        interactInput(Input.GetButton("Interact"));
    }
}