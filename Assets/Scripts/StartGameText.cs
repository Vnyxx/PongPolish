using UnityEngine;

public class StartGameText : MonoBehaviour
{
    BallMovement ballMovement;
    GameObject playText;
    void Start()
    {
        ballMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<BallMovement>();
        playText = GameObject.FindGameObjectWithTag("PlayText");
    }

    void Update()
    {
        if (ballMovement.isPlay) playText.SetActive(false);
        else playText.SetActive(true);
    }
}
