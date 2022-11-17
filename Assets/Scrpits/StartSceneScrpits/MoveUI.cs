using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUI : MonoBehaviour
{
    public Transform backGroud;
    public float moveSpeedUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        backGroud.transform.position -= new Vector3(moveSpeedUI,0,0);
        if(backGroud.transform.position.x <= -100 && backGroud.transform.position.x >=-300)
        {
            backGroud.transform.position = new Vector3(-1200, 294, 13);
        }
        else if(backGroud.transform.position.x <= -2000 && backGroud.transform.position.x >= -2100)
        {
            backGroud.transform.position = new Vector3(-3400, 294, 13);
        }
        else if (backGroud.transform.position.x <= -4200)
        {
            backGroud.transform.position = new Vector3(945, 294, 13);
        }
    }
}
