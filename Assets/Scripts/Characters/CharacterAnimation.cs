using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimation : MonoBehaviour{
    [SerializeField] private Animator anim;
    [SerializeField] private string currentAnim;

    void OnEnable(){
        anim = GetComponent<Animator>();
    }

    public void Animate(string animName){
        if(animName != currentAnim){
            anim.Play(animName);
            currentAnim = animName;
        }
    }
}