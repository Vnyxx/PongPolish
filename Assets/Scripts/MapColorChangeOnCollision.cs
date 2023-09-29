using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MapColorChangeOnCollision : ScriptAdder<BallMovement>
{
    List<SpriteRenderer> spriteRenderersList = new List<SpriteRenderer>();
    protected override void Awake()
    {
        base.Awake();
        //finds type of spriterenderer in array
        SpriteRenderer[] allSpriteRenderers = FindObjectsOfType<SpriteRenderer>();
        //adds the found sr to the list
        spriteRenderersList.AddRange(allSpriteRenderers);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (SpriteRenderer spriteRenderer in spriteRenderersList)
        {
            Color b = new Color(Random.Range(0.1f, 1f), Random.Range(0.1f, 1f), Random.Range(0.1f, 1f));
            spriteRenderer.color = b;            print(spriteRenderer.color);
        }
    }
}
