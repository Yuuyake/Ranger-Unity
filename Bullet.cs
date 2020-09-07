using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffect;

    public AudioSource onHitNonEnemy1;
    public AudioSource onHitNonEnemy2;
    public AudioSource onHitNonEnemy3;
    public GameObject usedArrow;
    public float bulletLife = 5f;
    public float bulletAngle;

    Transform arrowFrom;
    Transform arrowTo;

    System.Random rnd = new System.Random();

    void Start()
    {
        bulletAngle = gameObject.transform.eulerAngles.z;
        //print("Bullet Angle : " + bulletAngle);
    }
    // TO DO x + y nin r kadar çapında aynı ses çıkması lazım, kalanı random
    void OnCollisionEnter2D(Collision2D collision) {
        int randy = rnd.Next(1, 4);
        var hitter = collision.gameObject;

        Vector2 tempV = collision.contacts[0].point;
        //print("HITTER ANGLE : " + bulletAngle);
        Vector2 shootingVector = Shooting.AddAngleToVector(bulletAngle, new Vector2(1, 0));

        if (hitter.name.Contains("Enemy")){
            Shooting.FireWithAngle(usedArrow, hitter.transform, shootingVector, 0);
            Shooting.FireWithAngle(usedArrow, hitter.transform, shootingVector, 15);
            Shooting.FireWithAngle(usedArrow, hitter.transform, shootingVector, -15);
        }
        else{
            if (randy == 1){
                onHitNonEnemy1.Play();
            }
            else if (randy == 2){
                onHitNonEnemy2.Play();
            }
            else{
                onHitNonEnemy3.Play();
            }
        }
        GameObject arrowHitEffect = Instantiate(hitEffect, tempV, Quaternion.identity);
        Destroy(arrowHitEffect, 1f);
        Destroy(gameObject);

    }
    void FixedUpdate()
    {
        //float rotateAmount = 360.0f - Vector3.Angle(this.transform.right, this.GetComponent<Rigidbody2D>().velocity.normalized);
        //print("Amount : " + rotateAmount * 0.01f);
        //this.transform.Rotate(0,1,0);
    }

}
