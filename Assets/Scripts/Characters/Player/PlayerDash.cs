using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour{
    [SerializeField]private CharacterData player;
    [SerializeField]private Rigidbody2D rb2d;

    void Start(){
        PlayerInput.dash += Dash;
    }

    void Dash(){
        if(!player.IsDashing){
            player.MoveSpeed = player.DashSpeed;
            player.IsDashing = true;
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown(){
        yield return new WaitForSeconds(player.DashLength);
        player.MoveSpeed = player.NormalSpeed;
        player.IsDashOnCooldown = true;
        yield return new WaitForSeconds(player.DashCooldown);
        player.IsDashing = false;
        player.IsDashOnCooldown = false;
    }
}