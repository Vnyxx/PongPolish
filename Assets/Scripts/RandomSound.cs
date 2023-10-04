using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<BallMovement>().gameObject;
        ball.AddComponent<JannisScript>();
    }

    // Update is called once per frame
    
}
