using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class JannisScript : MonoBehaviour
{
    AudioClip audio1;
    AudioClip audio2;
    AudioClip audio3;
    AudioClip audio4;
    AudioClip audio5;
    AudioClip audio6;

    List<AudioClip> audioList = new List<AudioClip>();

    public AudioSource audioSource;
    public RandomSound randomSound;
   
    // Start is called before the first frame update
    void Start()
    {
         audioSource = gameObject.AddComponent<AudioSource>(); //adds a audiosource component so the audio can play
        // randomSound = gameObject.GetComponent<RandomSound>();

        audio1 = Resources.Load<AudioClip>("Audios/bone"); //loads a file into the variable
        audio2 = Resources.Load<AudioClip>("Audios/bullet");
        audio3 = Resources.Load<AudioClip>("Audios/cave");
        audio4 = Resources.Load<AudioClip>("Audios/gordon");
        audio5 = Resources.Load<AudioClip>("Audios/npesta");
        audio6 = Resources.Load<AudioClip>("Audios/ping"); 

        audioList.Add(audio1);
        audioList.Add(audio2);
        audioList.Add(audio3);
        audioList.Add(audio4);
        audioList.Add(audio5);
        audioList.Add(audio6);
    }
    void OnCollisionEnter2D(Collision2D collision2D)
    {
        int Randomizer = Random.Range(0, audioList.Count); //random number
        print(Randomizer);
        audioSource.PlayOneShot(audioList[Randomizer]); //plays sound
    }
}
