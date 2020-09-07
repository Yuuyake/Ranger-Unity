using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    private Transform firePoint;
    public GameObject bulletObj;
    public Camera cam;

    public Sprite freeSprite;
    public Sprite midSprite;
    public Sprite holdSprite;

    public int splitShoot;
    public int brustShoot;

    public AudioClip onRelSound1;
    public AudioClip onRelSound2;
    public AudioClip onRelSound3;

    public float bulletForce = 20f;
    public Rigidbody2D bowBody;

    float lookingAngle;
    int state = 0;
    System.Random rnd = new System.Random();
    Vector2 mousePos;
    float archerySpeed = 0.2f;
    GameObject preBullet = null;

    //state 0 = free
    //state 1 = midd
    //state 2 = holdSprite
    //state 3 = release

    void Start(){
        firePoint = gameObject.transform.GetChild(0).gameObject.transform;
    }
    void Update(){

        if (state == 0) {
            this.GetComponent<SpriteRenderer>().sprite = freeSprite;

            // prepare to fire
            if (Input.GetButton("Fire1")) {
                //WaitForSeconds(archerySpeed);
                state = 1;
                //print("State Changed to : " + state);
            }

        }
        else if (state == 1) {
            // change mid state animation then go to holding arrow state
            this.GetComponent<SpriteRenderer>().sprite = midSprite;
            //WaitForSeconds(archerySpeed);
            state = 2;
            //print("State Changed to : " + state);

        }
        else if (state == 2) {
            this.GetComponent<SpriteRenderer>().sprite = holdSprite;

            if (preBullet == null) {
                preBullet = Instantiate(bulletObj, firePoint.position, firePoint.rotation);
            }
            else {
                preBullet.transform.position = bowBody.transform.position;
                preBullet.transform.rotation = bowBody.transform.rotation;
            }

            // button released, go fire state 
            if (Input.GetButton("Fire1") == false) {
                state = 3;
                //print("State Changed to : " + state);
                Destroy(preBullet);
            }
        }
        else if (state == 3) {

            StartCoroutine(piercingShoot(splitShoot, brustShoot));
            state = 0;
            //print("State Changed to : " + state);

        }
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);


    }

    IEnumerator piercingShoot(int splitShoot = 1, int brustShoot = 1 ){

        for (int i = 0; i < brustShoot; i++) {

            //print("Will Shoot \"" + splitShoot + "\" split and \"" + brustShoot + "\" brust!!!");
            int randy = rnd.Next(1, 4);

            // MAKE SHOOTING SOUNDS
            if (randy == 1) { AudioSource.PlayClipAtPoint(onRelSound1, Camera.main.transform.position); }
            else if (randy == 2) { AudioSource.PlayClipAtPoint(onRelSound2, Camera.main.transform.position); }
            else { AudioSource.PlayClipAtPoint(onRelSound3, Camera.main.transform.position); }

            // SHOOT GOD DAMN ARROWs
            Vector2 lookDir = mousePos - bowBody.position;
            print("Calculated Dir : " + lookDir.normalized);

            //if (splitShoot > 0) { FireWithAngle(bulletObj, firePoint, lookDir, 0 ,bulletForce); }
            //if (splitShoot > 1) { FireWithAngle(bulletObj, firePoint, lookDir, 15,bulletForce); }
            //if (splitShoot > 2) { FireWithAngle(bulletObj, firePoint, lookDir,-15,bulletForce); }
            yield return new WaitForSeconds(archerySpeed);
        }
    }
    public static void FireWithAngle(GameObject _bulletObj, Transform _firePoint, Vector2 _lookDir, int sapmaAngle = 0, float _bulletForce = 20f) {

        float fireAngle = Mathf.Atan2(_lookDir.y, _lookDir.x) * Mathf.Rad2Deg + sapmaAngle;
        Vector2 fireVector = AddAngleToVector(sapmaAngle, _lookDir) * _bulletForce;

        GameObject bullet = Instantiate(_bulletObj, _firePoint.position, _firePoint.rotation);
        Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
        bulletBody.rotation = fireAngle;
        bulletBody.AddForce(fireVector, ForceMode2D.Impulse); // firing the bullet

        Destroy(bullet, _bulletObj.GetComponent<Bullet>().bulletLife);
    }


    public static Vector2 AddAngleToVector(float angle,Vector2 original)
    {
        angle *= Mathf.Deg2Rad;// angle to be added to original Vector, in radian
        float baseAngle = Mathf.Atan2(original.y,original.x); // in radian
        Vector2 retVector = new Vector2(Mathf.Cos(baseAngle + angle), Mathf.Sin(baseAngle + angle));
        return retVector;
    }
}
