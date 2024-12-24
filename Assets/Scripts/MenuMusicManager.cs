using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusicManager : MonoBehaviour
{
    private AudioSource audioSource;

    void Awake()
    {
        if (FindObjectsOfType<MenuMusicManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);

        // Obtener el componente AudioSource
        audioSource = GetComponent<AudioSource>();

        // Reproducir la música al iniciar
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
