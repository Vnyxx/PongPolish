using System.Collections;
using UnityEngine;

public class FreezeOnCollision : ScriptAdder<BallMovement>
{
    private const float FreezeForMilliseconds = 100;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D _collision)
    {
        Freeze();
    }

    private void Freeze()
    {
        Time.timeScale = 0;
        StartCoroutine(UnFreeze());
    }

    private IEnumerator UnFreeze()
    {
        yield return new WaitForSecondsRealtime(FreezeForMilliseconds / 1000);
        Time.timeScale = 1;
    }
}