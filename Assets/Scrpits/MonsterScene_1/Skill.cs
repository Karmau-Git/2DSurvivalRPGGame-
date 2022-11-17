using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public Image skill;
    public GameObject skillPre;
    float CD=0;
    Quaternion rotation;
    void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(CD>= 5)
            {
                CD = 0;
                Instantiate(skillPre,gameObject.transform.position,rotation);
            }
        }
        CD += Time.deltaTime;
        skill.fillAmount = CD / 5f;
        
    }
}
