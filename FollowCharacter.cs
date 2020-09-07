using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCharacter : MonoBehaviour
{
    public GameObject Camera;
    public GameObject Ball;
    // Update is called once per frame
    void Update() {

        Camera.transform.position = new Vector3(Ball.transform.position.x, Ball.transform.position.y , -10);
    }
}
