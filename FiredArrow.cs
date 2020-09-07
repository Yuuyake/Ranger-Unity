using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredArrow : MonoBehaviour
{
    public GameObject arrowPathMarker;
    //public Rigidbody2D myBowRigid;
    public float firedDirection;
    public float firedTime;
    public float timePast;
    public float firedAngle;
    public float totalFlyingTime = 3;
    public float arrowSpeed = 5;
    float lastInstantinate;
    bool isFired = false;

    public Vector2 startingVector;
    public Vector2 endingVector;
    public Vector2 currentVelVec;

    void Start(){
        //firedDirection = 0;
        firedTime = Time.time;
        timePast = Time.time - firedTime;
        firedAngle = (90 + firedDirection) / 2;
        lastInstantinate = 0;
        startingVector = Vector2FromAngle(firedAngle);
        endingVector = Vector2FromAngle(3 * firedDirection / 2 - 45);
        currentVelVec = startingVector;

        print("Fired Direction : " + firedDirection);
        print("Fired Angle : " + firedAngle);
        print("Starting Vector : " + startingVector);
        print("Ending Vector : " + endingVector);
        isFired = true;
        Destroy(gameObject, 10f);
    }
    void Update(){
        if (isFired == true){
            timePast = Time.time - firedTime;
            //print("Fired " + timePast);

            if (gameObject.GetComponent<Rigidbody2D>().velocity.normalized != endingVector){
                currentVelVec = Vector2.Lerp(startingVector, endingVector, timePast / totalFlyingTime);// holds the instant value of vector of flying arrow 
                gameObject.GetComponent<Rigidbody2D>().velocity = currentVelVec * arrowSpeed;
                gameObject.GetComponent<Rigidbody2D>().rotation = Mathf.Atan2(currentVelVec.y, currentVelVec.x) * Mathf.Rad2Deg;
                ScoutMarker();
            }
            else{
                gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
            }
        }
    }
    void ScoutMarker(){
        if ( (Time.time - lastInstantinate) > 0.3 && timePast <= totalFlyingTime){
            lastInstantinate = Time.time;
            GameObject marker = Instantiate(arrowPathMarker, gameObject.transform.position, gameObject.transform.rotation);
            marker.transform.GetChild(0).gameObject.GetComponent<TextMesh>().text = gameObject.GetComponent<Rigidbody2D>().velocity.ToString();
        }
    }

    public Vector2 Vector2FromAngle(float angle){
        angle *= Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)).normalized;
    }
}
