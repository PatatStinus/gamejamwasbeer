using System.Collections;
using UnityEngine;

public class Audiomanager : MonoBehaviour
{
    public AudioClip[] songs;
    private AudioSource audioSource;
    private int currentSongIndex = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextSong();
    }

    private void PlayNextSong()
    {
        audioSource.Stop();
        audioSource.clip = songs[currentSongIndex];
        audioSource.Play();

        currentSongIndex = (currentSongIndex + 1) % songs.Length; // Loop back to the first song if all have been played
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            StartCoroutine(PlayNextSongWithDelay());
        }
    }

    private IEnumerator PlayNextSongWithDelay()
    {
        yield return new WaitForSeconds(1f); // Delay before playing the next song
        PlayNextSong();
    }
}