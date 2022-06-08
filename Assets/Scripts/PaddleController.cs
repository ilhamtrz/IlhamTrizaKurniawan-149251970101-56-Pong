using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public int speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //move the paddle based on the input
        MovePaddle(GetInput());
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(upKey))
        {
            //move the paddle up
            return Vector2.up * speed;
        }
        else if (Input.GetKey(downKey))
        {
            //move the paddle down
            return Vector2.down * speed;
        }
        return Vector2.zero;
    }

    private void MovePaddle(Vector2 movement)
    {
        rig.velocity = movement;
    }
}
