using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Camera cam;
    public Rigidbody2D rb;
    public Animator animator;


    Vector2 movement;
    Vector2 mousePos;
    // bool isPressedButton0 = false;
    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        mousePos = cam.ScreenToWorldPoint((Input.mousePosition));
    }

    void FixedUpdate() // runs with every fixed time in CPU , u can miss time between calculations
    {
        rb.MovePosition(rb.position + (movement * moveSpeed * Time.fixedDeltaTime));

        ////Debug.Log("Pressed secondary button.");
        //Vector2 lookDir = mousePos - rb.position;
        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        //rb.rotation = angle;

    }
}
