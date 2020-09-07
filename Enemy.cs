using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource onHitSound1;
    public AudioSource onHitSound2;
    public AudioSource onHitSound3;

    System.Random rnd = new System.Random();
    public TextMesh health;
    int hp = 100;
    // Start is called before the first frame update
    void Start()
    {
        onHitSound1.enabled = true;
        onHitSound2.enabled = true;
        onHitSound3.enabled = true;
    }

    // Update is called once per frame
    void Update(){
        
    }
    void FixedUpdate(){


        if(health.color != Color.red)
            health.color = Color.red;

        gameObject.GetComponent<SpriteRenderer>().color = Color.green;


    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        health.text = "Health " + hp--;
        health.color = Color.black;
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;

        //GameObject hitObj = Instantiate(hitEffect, tempV, Quaternion.identity);
        //Destroy(hitObj, 1f);

        int randy = rnd.Next(1, 4);
        if (randy == 1){
            onHitSound1.Play();
            print(" Sound : onHitSound1");
        }
        else if (randy == 2){
            onHitSound2.Play();
            print(" Sound : onHitSound2");
        }
        else{
            onHitSound3.Play();
            print(" Sound : onHitSound3");
        }
    }
}
