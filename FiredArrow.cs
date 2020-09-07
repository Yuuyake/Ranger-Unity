using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredArrow : MonoBehaviour
{
    GameObject arrowObj;
    public GameObject arrowPathMarker;
    public float firedTime;
    public float timePast;
    public float firedAngle;
    public float totalFlyingTime;
    public float arrowSpeed;
    float lastInstantinate;

    public Vector2 startingVector;
    public Vector2 endingVector;
    public Vector2 currentVelVec;

    public FiredArrow(float firedDirection, GameObject refArrow , GameObject refObj, float _arrowSpeed){
        this.arrowObj = Instantiate(refArrow, refObj.transform.position, refObj.transform.rotation);
        this.firedTime = Time.time;
        this.timePast = Time.time - firedTime;
        this.firedAngle = (90-firedDirection)/2;
        this.arrowSpeed = _arrowSpeed;
        this.lastInstantinate = 0;
        this.startingVector = Vector2FromAngle(firedAngle);
        this.endingVector = Vector2FromAngle(3*firedAngle/2 -45);
        this.currentVelVec = startingVector;

        print("Fired Direction : " + firedDirection);
        print("Fired Angle : " + firedAngle);
        print("Starting Vector : " + startingVector);
        print("Ending Vector : " + endingVector);
    }

    void Start(){

    }
    void Update(){
        timePast = Time.time - firedTime;
        currentVelVec = Vector2.Lerp(startingVector,endingVector, timePast / totalFlyingTime);// holds the instant value of vector of flying arrow 

        if (arrowObj.GetComponent<Rigidbody2D>().velocity.normalized != endingVector){
            arrowObj.GetComponent<Rigidbody2D>().velocity = currentVelVec * arrowSpeed;
            arrowObj.GetComponent<Rigidbody2D>().rotation = Mathf.Atan2(currentVelVec.y, currentVelVec.x) * Mathf.Rad2Deg;
            ScoutMarker();
        }
        else
        {
            arrowObj.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
    }
    void ScoutMarker(){
        if ( (Time.time - lastInstantinate) > 0.5 && Time.time <= totalFlyingTime){
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
