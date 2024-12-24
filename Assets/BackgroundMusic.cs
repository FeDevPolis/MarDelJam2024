using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] List<AudioClip> MusicClips;
    [SerializeField] private AudioSource audioSource;



    private void Start()
    {
        audioSource.loop=true;
        GameManager.StartWeekEvent.AddListener(PlayRandomMusic);
        GameManager.EndWeekEvent.AddListener(EndMusic);
    }

    private void PlayRandomMusic()
    {
        audioSource.clip = MusicClips[UnityEngine.Random.Range(0,MusicClips.Count)];
        audioSource.Play();
    }

    private void EndMusic()
    {
        audioSource.Stop();
    }
}
