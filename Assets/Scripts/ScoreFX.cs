using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreFX : ScriptAdder<BallMovement>
{
    TMP_Text[] scoresText;
    private float tweenDuration = 1.0f;
    private float overshoot = 1.2f;
    int[] prevScore = {0, 0};
    int[] currentScore;
    void Animate(int side)
    {
        TMP_Text chosenScore = scoresText[side];
        Vector3 originPosition = chosenScore.transform.position;
        chosenScore.transform.position = new Vector3(chosenScore.transform.position.x, chosenScore.transform.position.y - 100, chosenScore.transform.position.z);
        Vector3 startPosition = chosenScore.transform.position;

        float elapsedTime = 0.0f;

        while (elapsedTime < tweenDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp((elapsedTime / tweenDuration  ), 0, 1);
            chosenScore.transform.position = TweenBack(startPosition, originPosition, t, overshoot);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        BallMovement ballmovement = GetComponent<BallMovement>();
        scoresText = ballmovement.playerScoreText;
        currentScore = ballmovement.playerScoreNumber;
    }

    // Update is called once per frame
    void Update()
    {
        print(currentScore[0]);
        if (currentScore != prevScore)
        {
            print("yes");
            if (currentScore[0] != prevScore[0])
            {
                print("yes2");
                Animate(0);
            }
            else if (currentScore[1] != prevScore[1])
            {
                print("yes3");
                Animate(1);
            }
            prevScore = currentScore;
        }
    }

    private Vector3 TweenBack(Vector3 start, Vector3 end, float t, float s)
    {
        t = Mathf.Clamp(t, 0, 1);
        return Vector3.Lerp(start, end, 1.0f + (s + 1.0f) * Mathf.Pow(t - 1.0f, 3) + s * Mathf.Pow(t - 1.0f, 2));
    }
}
