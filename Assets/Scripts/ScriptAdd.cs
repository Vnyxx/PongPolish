using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptAdd : MonoBehaviour
{
    GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        ball = FindObjectOfType<BallMovement>().gameObject;
        ball.AddComponent<RandomSoundWhenCollision>();
    }

    // Update is called once per frame
    
}
