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
        PlaySong(currentSongIndex);
    }

    private void PlaySong(int songIndex)
    {
        audioSource.Stop();
        audioSource.clip = songs[songIndex];
        audioSource.Play();
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

        currentSongIndex = (currentSongIndex + 1) % songs.Length; // Move to the next song index
        PlaySong(currentSongIndex);
    }
}