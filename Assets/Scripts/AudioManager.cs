using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Can remove and add sounds as needed while we develop the game

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource;
    public AudioClip MainMenuMusic;
    public AudioClip GameMusic;
    public AudioClip lossMusic;

    /*
     * Sets the default music of the game
     */
    public void Start()
    {
        musicSource.clip = GameMusic;
        musicSource.Play();
    }

    /*
     * Changes the main music to the loss theme
     */
    public void ToggleLossMusic()
    {
        musicSource.clip = lossMusic;
        musicSource.Play();
    }
}