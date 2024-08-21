using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour{
    public static GameObject instance;

    void OnEnable(){
        DontDestroyOnLoad(this.gameObject);
        if(instance == null){ //Se asegura que solo haya un objeto de este tipo
            instance = this.gameObject;
        }else{
            Destroy(gameObject);
        }
    }
}