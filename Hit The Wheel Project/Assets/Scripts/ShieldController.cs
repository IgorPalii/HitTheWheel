using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    private const float MAX_SPEED = 200f, MIN_SPEED = 10f;
    private const int HIT_COUNTER = 3;
    private float speed;
    private int hitCounter;

    private void Start()
    {
        speed = Random.Range(MIN_SPEED, MAX_SPEED);
        hitCounter = 0;
    }

    private void FixedUpdate()
    {
        transform.Rotate(0f, 0f, speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        hitCounter++;
        if (hitCounter == HIT_COUNTER)
        {
            speed = Random.Range(MIN_SPEED, MAX_SPEED);
            hitCounter = 0;
        }
    }
}
