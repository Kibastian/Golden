using UnityEngine;
using System;
using System.Collections;


public class SoundManager : MonoBehaviour
{

    protected static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (SoundManager)FindObjectOfType(typeof(SoundManager));

                if (instance == null)
                {
                    Debug.LogError("SoundManager Instance Error");
                }
            }

            return instance;
        }
    }

    // Volume
    public SoundVolume volume = new SoundVolume();

    // === AudioSource ===
    // BGM
    private AudioSource BGMsource;
    // SE
    private AudioSource[] SEsources = new AudioSource[16];

    // === AudioClip ===
    // BGM
    public AudioClip BGM;
    // SE
    public AudioClip TapSE;

    void Awake()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("SoundManager");
        if (obj.Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }

        // BGM AudioSource
        BGMsource = gameObject.AddComponent<AudioSource>();
        BGMsource.loop = true;

        // SE AudioSource
        for (int i = 0; i < SEsources.Length; i++)
        {
            SEsources[i] = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Mute Setting
        volume.Mute = game_manager.sound_mute;
        BGMsource.mute = volume.Mute;
        foreach (AudioSource source in SEsources)
        {
            source.mute = volume.Mute;
        }
        // Volume Setting
        BGMsource.volume = volume.BGM;
        foreach (AudioSource source in SEsources)
        {
            source.volume = volume.SE;
        }
    }
		
    public void PlayBGM()
    {
        if (BGMsource.clip == BGM)
        {
            return;
        }
        BGMsource.Stop();
        BGMsource.clip = BGM;
        BGMsource.Play();
    }

    public void StopBGM()
    {
        BGMsource.Stop();
        BGMsource.clip = null;
    }
		
    public void PlaySE()
    {
        foreach (AudioSource source in SEsources)
        {
            if (false == source.isPlaying)
            {
                source.clip = TapSE;
                source.Play();
                return;
            }
        }
    }

    public void StopSE()
    {
        foreach (AudioSource source in SEsources)
        {
            source.Stop();
            source.clip = null;
        }
    }
}

// Volume Class
[Serializable]
public class SoundVolume
{
    public float BGM = 1.0f;
    public float SE = 1.0f;
    public bool Mute = false;

    public void Init()
    {
        BGM = 1.0f;
        SE = 1.0f;
        Mute = false;
    }
}