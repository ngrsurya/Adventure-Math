using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource[] Music;
    public static AudioClip Jump;

    public static AudioManager instance;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {

        Jump = Resources.Load<AudioClip>("Jump");
        audioSrc = GetComponent<AudioSource>();


        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic(int musicToPlay)
    {
        if (!Music[musicToPlay].isPlaying)
        {
            StopMusic();
            if (musicToPlay < Music.Length)
            {
                Music[musicToPlay].Play();
            }
        }
    }

    public void StopMusic()
    {
        for (int i = 0; i < Music.Length; i++)
        {
            Music[i].Stop();
        }
    }
    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSrc.PlayOneShot(Jump);
                break;
        }

    }
}
