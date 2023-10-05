using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundWhenCollision : MonoBehaviour
{
    AudioClip[] audios = new AudioClip[6]; 
    AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>(); //adds a audiosource component so the audio can play
        audios = Resources.LoadAll<AudioClip>("Audios"); //loads all audio in "Audios" into the array
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        int Randomizer = Random.Range(0, audios.Length); //random number
        print(Randomizer);
        audioSource.PlayOneShot(audios[Randomizer]); //plays sound
    }
}
