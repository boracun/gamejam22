using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRotator : MonoBehaviour
{
    //gun movement
    public SpriteRenderer sr_g;
    private Vector3 gunDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // gun rotatation
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 5.23f;

        gunDirection = Camera.main.WorldToScreenPoint(transform.position);
        mousePos.x = mousePos.x - gunDirection.x;
        mousePos.y = mousePos.y - gunDirection.y;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPosition = Camera.main.ScreenToWorldPoint(screenPosition);

        if (worldPosition.x < transform.position.x) 
        {
            sr_g.flipX = true;
            mousePos = Input.mousePosition;

            gunDirection = Camera.main.WorldToScreenPoint(transform.position);
            mousePos.x = gunDirection.x - mousePos.x;
            mousePos.y = gunDirection.y - mousePos.y;

            angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        }
        else if (worldPosition.x > transform.position.x) sr_g.flipX = false;
    }
}
