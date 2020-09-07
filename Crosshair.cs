using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    Vector2 mousePos;
    Vector2 movement;

    public Rigidbody2D rb;
    public Rigidbody2D selfrb;
    public Camera cam;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint((Input.mousePosition));
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    void FixedUpdate() // runs with every fixed time in CPU , u can miss time between calculations
    {
        transform.position = mousePos;

        Vector2 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        selfrb.rotation = angle + 90;

    }
}
