using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour{
    [SerializeField]public CharacterData player;
    public delegate void DirectionalInput(float xAxis, float yAxis);
    public delegate void DashInput();
    public delegate void AttackInput();
    public delegate void ProtectInput(bool button);
    public delegate void InteractInput();
    public static DirectionalInput direction;
    public static DashInput dash;
    public static AttackInput attack;
    public static ProtectInput protect;
    public static InteractInput interact;

    void Update(){
        if(player.IsAlive){
            direction(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
            protect(Input.GetButton("Protect"));
            if(Input.GetButton("Dash")) dash();
            if(Input.GetButton("Attack")) attack();
            //if(Input.GetButton("Interact")) interact();
        }
    }
}