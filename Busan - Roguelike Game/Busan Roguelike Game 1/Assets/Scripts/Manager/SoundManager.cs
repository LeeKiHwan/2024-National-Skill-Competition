using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioSource bgmSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip sfx)
    {
        GameObject go = new GameObject(sfx.name);
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = sfx;
        source.Play();
        Destroy(go, sfx.length);
    }

    public void PlayBGM(AudioClip bgm)
    {
        bgmSource.Stop();
        bgmSource.clip = bgm;
        bgmSource.loop = true;
        bgmSource.Play();
    }
}
