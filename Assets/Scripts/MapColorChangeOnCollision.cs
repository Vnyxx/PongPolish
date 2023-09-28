using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            int r = Random.Range(0, 9);
            switch (r)
            {
                case 0:
                    spriteRenderer.color = Color.red;
                    break;
                case 1:
                    spriteRenderer.color = Color.green;
                    break;
                case 2:
                    spriteRenderer.color = Color.blue;
                    break;
                case 3:
                    spriteRenderer.color = Color.yellow;
                    break;
                case 4:
                    spriteRenderer.color = Color.cyan;
                    break;
                case 5:
                    spriteRenderer.color = Color.magenta;
                    break;
                case 6:
                    spriteRenderer.color = Color.blue;
                    break;
                case 7:
                    spriteRenderer.color = Color.white;
                    break;
                case 8:
                    spriteRenderer.color = Color.gray;
                    break;
            }
        }
    }
}
