using System.Collections;
using TMPro;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float ballVelocity = 3000;

    Rigidbody2D rb;
    public bool isPlay;
    int randInt;
    public int extraForce;

    public TMP_Text[] playerScoreText;
    public int[] playerScoreNumber = { 0, 0 };

    float ballDirSpeedP1;
    float ballDirSpeedP2;

    public float dirSpeedMultiplier;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        randInt = RndNmbr(1, 3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "PlayerLeft")
            rb.AddForce(new Vector3(extraForce, ballDirSpeedP2, 0));

        if (collision.gameObject.tag == "PlayerRight")
            rb.AddForce(new Vector3(-extraForce, ballDirSpeedP1, 0));
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "BoundLeft")
            SetScore(1);

        if (other.gameObject.tag == "BoundRight")
            SetScore(0);
    }

    public void SetScore(int _player)
    {
        playerScoreNumber[_player]++;
        playerScoreText[_player].text = playerScoreNumber[_player].ToString();
        StartCoroutine(ResetBall(_player));
    }

    IEnumerator ResetBall(int _p)
    {
        rb.Sleep();
        rb.WakeUp();
        rb.isKinematic = true;
        randInt = _p;

        yield return new WaitForSeconds(2);

        transform.position = new Vector3(0, 0, 0);
        isPlay = false;
    }

    void Update()
    {
        ballDirSpeedP1 = Input.GetAxis("VerticalPlayerOne") * dirSpeedMultiplier;
        ballDirSpeedP2 = Input.GetAxis("VerticalPlayerTwo") * dirSpeedMultiplier;

        if (Input.GetKeyDown(KeyCode.Space) && isPlay == false)
            ShootBall();
    }

    void ShootBall()
    {
        transform.parent = null;
        isPlay = true;
        rb.isKinematic = false;

        float _ballVelocity = (randInt == 1) ? ballVelocity : -ballVelocity;
        rb.AddForce(new Vector3(_ballVelocity, Random.Range(-2000, 2000), 0));
    }

    int RndNmbr(int _x, int _y)
    {
        return Random.Range(_x, _y);
    }
}

