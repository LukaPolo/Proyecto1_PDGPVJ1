using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSound : MonoBehaviour{
    [SerializeField] private GameObject listener;

    void OnEnable(){
        listener = GameObject.FindWithTag("MainCamera");
    }

    public void PlaySound(AudioClip clip){
        AudioSource source = listener.AddComponent<AudioSource>();
        source.clip = clip;
        source.Play();
        Destroy(source, clip.length);
    }
}