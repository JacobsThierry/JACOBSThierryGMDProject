using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class audioManager
{

    private static AudioClip[] musicList;


public static void playPiouSound(int count, int damages){
        AudioClip weaponSound = Resources.Load<AudioClip>("sound/soundsEffects/Laser_Shoot9");
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        soundGameObject.AddComponent<soundObjectDestroyer>();
        if (weaponSound != null)
        {
            audioSource.clip = weaponSound;
            audioSource.pitch = 1f / (damages / 5f + count / 5f); //less damages = higher pitch
            if (audioSource.pitch < 0.3f)
            {
                audioSource.pitch = 0.3f;
            }
            else if (audioSource.pitch > 2f)
            {
                audioSource.pitch = 3f;
            }
            audioSource.Play();


        }
}

public static void playExplosion(float scale){
    AudioClip explosion = Resources.Load<AudioClip>("sound/soundsEffects/Explosion2");
    if(explosion != null){
            GameObject soundGameObject = new GameObject("Sound");
            AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
            soundGameObject.AddComponent<soundObjectDestroyer>();
            audioSource.clip = explosion;
            audioSource.pitch = 0.5f / scale;
            audioSource.Play();
    }
}

public static void playPlaygroundMusic(GameObject playground){
    musicList = Resources.LoadAll<AudioClip>("sound/musics/playground");
    AudioSource audioSource = playground.AddComponent<AudioSource>();
    audioSource.clip = (musicList[(int)Random.Range(0, musicList.Length - 1)]);
    audioSource.loop = true;
    audioSource.Play();

}

public static void playHUBMusic(GameObject hub){
        AudioClip clip = Resources.Load<AudioClip>("sound/musics/hub/Super Hexagon Soundtrack - Hexagonest Hexagon Stage");
        AudioSource audioSource = hub.AddComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
}

public static void playMenuMusic(GameObject menu){
    AudioClip menuMusic = Resources.Load<AudioClip>("sound/musics/mainMenue/Super Hexagon Soundtrack - Ending");
    if(menuMusic != null){
        Debug.Log("woooool");
        AudioSource asou = menu.AddComponent<AudioSource>();
        asou.clip = menuMusic;
        asou.loop = true;
        asou.Play();
    }
}

}
