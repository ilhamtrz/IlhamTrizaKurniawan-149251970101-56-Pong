using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private Rigidbody2D rig;
    private Vector3 initScale;
    private float initSpeed;

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initScale = gameObject.transform.localScale;
        initSpeed = speed;

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
        /*Debug.Log("TEST: " + movement);*/
        rig.velocity = movement;
    }

    public void ActivatePUSpeedUp(float magnitude, float duration)
    {
        speed *= magnitude;
        StartCoroutine(SpeedUpPaddleTimer(duration));
    }

    public void ActivatePULongPaddle(float magnitude, float duration)
    {
        gameObject.transform.localScale = new Vector3(initScale.x, initScale.y * magnitude, initScale.z);
        StartCoroutine(LongPaddleTimer(duration));
    }

    private IEnumerator LongPaddleTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        DeactivatePULongPaddle();
    }

    private IEnumerator SpeedUpPaddleTimer(float duration)
    {
        yield return new WaitForSeconds(duration);
        DeactivatePUSpeedUp();
    }

    public void DeactivatePULongPaddle()
    {

        gameObject.transform.localScale = new Vector3(initScale.x, initScale.y, initScale.z);
        
    }

    public void DeactivatePUSpeedUp()
    {
        speed = initSpeed;
    }
}
