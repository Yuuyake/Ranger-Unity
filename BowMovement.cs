using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BowMovement : MonoBehaviour
{
    Vector2 movement;
    Vector2 mousePos;
    public float moveSpeed = 5f;
    public Camera cam;

    Rigidbody2D bowBody;
    public Shooting myShooter;
    bool isSplit = false;
    bool isBrust = false;

    public GameObject arrowPathMarker;
    public GameObject arrow;
    public float totalFlyingTime = 2;

    public float arrowSpeed = 3;
    //List<FiredArrow> firedArrows = new List<FiredArrow>();

    void Start()
    {
        bowBody = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() // Update is called every frame, cant miss anything
    {
        if (Input.GetButtonUp("Fire1")){
            Instantiate(arrow, gameObject.transform.position, gameObject.transform.rotation);
        }

        isSplit = Input.GetKey("2") == true ? true : false;
        isBrust = Input.GetKey("1") == true ? true : false;

        if (isSplit == true)
            myShooter.splitShoot = 2;
        else
            myShooter.splitShoot = 1;

        if (isBrust == true)
            myShooter.brustShoot = 2;
        else
            myShooter.brustShoot = 1;

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        mousePos = cam.ScreenToWorldPoint((Input.mousePosition));

    }
    void FixedUpdate() // runs with every fixed time in CPU , u can miss time between calculations
    {
        bowBody.MovePosition(bowBody.position + (movement * moveSpeed * Time.fixedDeltaTime));
        Vector2 lookDir = mousePos - bowBody.position;
        float angle = Mathf.Atan2(lookDir.y , lookDir.x) * Mathf.Rad2Deg;
        bowBody.rotation = angle;
        
    }
}
