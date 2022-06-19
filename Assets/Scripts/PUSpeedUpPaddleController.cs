using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpPaddleController : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float duration;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public float magnitude;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            if (ball.GetComponent<BallController>().leftLastCol())
            {
                leftPaddle.GetComponent<PaddleController>().ActivatePUSpeedUp(magnitude, duration);
                manager.RemovePowerUp(gameObject);
            }
            else
            {
                rightPaddle.GetComponent<PaddleController>().ActivatePUSpeedUp(magnitude, duration);
                manager.RemovePowerUp(gameObject);
            }

        }
    }
}
