using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public Vector2 speed;
    private Rigidbody2D rig;
    public Vector2 resetPosition;
    private bool isLeftLastCol;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Padel Kiri")
        {
            isLeftLastCol = true;
        }
        else if(collision.gameObject.name == "Padel Kanan")
        {
            isLeftLastCol = false;
        }
        
    }

    public bool leftLastCol()
    {
        return isLeftLastCol;
    }

    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        rig.velocity = speed;
    }
    
    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
    }

    public void ActivatePUSpeedUp(float magnitude, float duration)
    {
        rig.velocity *= magnitude;
        StartCoroutine(SpeedUpTimer(magnitude, duration));
    }

    public void DeactivatePUSpeedUp(float magnitude)
    {
        rig.velocity /= magnitude;
    }

    private IEnumerator SpeedUpTimer(float magnitude, float duration)
    {
        yield return new WaitForSeconds(duration);
        DeactivatePUSpeedUp(magnitude);
    }
}
