using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float playerSpeed = 10f;
    [SerializeField] float yClampValue = 7.5f;
    public string playerInputName;

    void Update()
    {
        var yPos = transform.position.y + (Input.GetAxis(playerInputName) * Time.deltaTime * playerSpeed);
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(yPos, -yClampValue, yClampValue), 0);
    }
}
