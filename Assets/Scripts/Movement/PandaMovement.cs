using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PandaMovement : MonoBehaviour
{
    public float pandaSpeed;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    private Vector2 pandaDirection;

    // Update is called once per frame
    void Update()
    {
        float directionX;
        if (Input.GetKey(KeyCode.A))
        {
            directionX = -1f;
            sr.flipX = true;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            directionX = 1f;
            sr.flipX = false;
        }
        else directionX = 0f;

        float directionY;
        if (Input.GetKey(KeyCode.S)) directionY = -1f;
        else if (Input.GetKey(KeyCode.W)) directionY = 1f;
        else directionY = 0f;
        
        pandaDirection = new Vector2(directionX, directionY).normalized;
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(pandaDirection.x * pandaSpeed, pandaDirection.y * pandaSpeed);
    }

}
