using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_BurstAndSplit : MonoBehaviour
{
    public Text burst;
    public Text split;
    public Text Vanguard;

    public Shooting myShooter;
    void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void Update(){
        burst.text = "press1 Brust " + myShooter.brustShoot.ToString();
        burst.color = myShooter.brustShoot > 1 ? Color.red : Color.black;

        split.text = "press2 Split " + myShooter.splitShoot.ToString();
        split.color = myShooter.splitShoot > 1 ? Color.red : Color.black;

        //Vanguard.text = Input.mousePosition + " Vanguard";

    }
}
