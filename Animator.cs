using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    public Animation[] bows;
    Vector3 mousePos;
    public Camera cam;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint((Input.mousePosition));
        Vector3 lookDir = mousePos - rb.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        //rb.rotation.SetAxisAngle(lookDir, angle);

        //if (Input.GetButton("Fire1"))
        //{
        //    bows[0].Play();
        //    print("HEEYYEYEYEYEY");

        //}
    }
}
