using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
        if (Input.GetKey(KeyCode.A)) directionX = -1f;
        else if (Input.GetKey(KeyCode.D)) directionX = 1f;
        else directionX = 0f;

        float directionY;
        if (Input.GetKey(KeyCode.S)) directionY = -1f;
        else if (Input.GetKey(KeyCode.W)) directionY = 1f;
        else directionY = 0f;
        
        pandaDirection = new Vector2(directionX, directionY).normalized;

        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (worldPosition.x < transform.position.x) sr.flipX = true;
        else if (worldPosition.x > transform.position.x) sr.flipX = false;
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(pandaDirection.x * pandaSpeed, pandaDirection.y * pandaSpeed);
    }

}
