using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Character : MonoBehaviour{
    [SerializeField]public CharacterData chara;
    [SerializeField]public Slider visualHealth;

    private void Awake(){
        chara.Health = chara.MaxHealth;
    }

    void Update(){
        visualHealth.GetComponent<Slider>().value = chara.Health;
    }

    public abstract void CheckHealth();

    public virtual void TakeDamage(int attackDamage){
        chara.Health -= attackDamage;
        CheckHealth();
    }
}