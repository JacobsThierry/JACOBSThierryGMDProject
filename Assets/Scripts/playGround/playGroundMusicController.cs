using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playGroundMusicController : MonoBehaviour
{

private AudioClip[] musicList;
private AudioSource audioSource;
/*
    // Start is called before the first frame update
    void Start()
    {
        musicList = Resources.LoadAll<AudioClip>("musics/playground");
        audioSource = (AudioSource) gameObject.AddComponent(typeof(AudioSource));
        playMusic();
        
    }

void playMusic(){
    audioSource.clip = (musicList[(int)Random.Range(0, musicList.Length - 1)]);
    audioSource.Play();
}
    // Update is called once per frame
    void Update()
    {
        if(!audioSource.isPlaying){
            playMusic();
        }
    }*/
}
