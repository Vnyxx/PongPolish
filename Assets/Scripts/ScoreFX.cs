using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ScoreFX : ScriptAdder<BallMovement>
{
    TMP_Text[] scoresText;
    private float tweenDuration = 1.0f;
    private float overshoot = 1.7f;
    private int[] prevScore = {0, 0};
    int[] currentScore;
    void Animate(int side)
    {
        TMP_Text chosenScore = scoresText[side];
        Vector3 originPosition = chosenScore.gameObject.transform.position;
        //verplaats de score naar beneden
        chosenScore.gameObject.transform.position = new Vector3(chosenScore.gameObject.transform.position.x, chosenScore.gameObject.transform.position.y - 25, chosenScore.gameObject.transform.position.z);
        Vector3 startPosition = chosenScore.gameObject.transform.position;

        //waar de score eerst was voordat ik het verplaatste, is de goal position nu
        StartCoroutine(Tween(startPosition, originPosition, chosenScore.gameObject));
    }

    private IEnumerator Tween(Vector3 startPosition, Vector3 goalPosition, GameObject obj)
    {
        float elapsedTime = 0.0f;

        //terwijl de tween niet is afgelopen (voorbeeld: 0:01/1:52 dan is dat tijdGeweest/totaleTijd)
        while (elapsedTime < tweenDuration)
        {
            //tijd gaat af
            elapsedTime += Time.deltaTime;
            //pak normalized waarde van tijd (%)
            float currentTime = Mathf.Clamp(elapsedTime / tweenDuration, 0, 1);
            //formule voor de timestamp van positie tussen start en goal van waar de huidige positie is
            obj.transform.position = Vector3.Lerp(startPosition, goalPosition, 1.0f + (overshoot + 1.0f) * Mathf.Pow(currentTime - 1.0f, 3) + overshoot * Mathf.Pow(currentTime - 1.0f, 2));
            //wacht totdat volgende frame begint (alsof in update functie is)
            yield return null;
        }

        //weet zeker dat de positie goal heeft gehaald
        obj.transform.position = goalPosition;
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
        //als de currentscore veranderd is
        if (currentScore[0] != prevScore[0] || currentScore[1] != prevScore[1])
        {
            //als rechts veranderd is
            if (currentScore[0] != prevScore[0])
            {
                //geef de kant van score naar animate functie
                Animate(0);
                prevScore[0] = currentScore[0];
            }
            //als links veranderd is
            else if (currentScore[1] != prevScore[1])
            {
                Animate(1);
                prevScore[1] = currentScore[1];
            }
        }
    }
}
