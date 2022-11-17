using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Timer : MonoBehaviour
{
    public TextMeshProUGUI textTimer;
    private int timer = 300;
    float timer1 = 0;
    public GameObject image;
    private void Update()
    {
        timer1 += Time.deltaTime;
        if (timer1 >= 1)
        {
            timer -= 1;
            timer1 = 0;
        }
        textTimer.text = timer.ToString();
        if (timer < 0)
        {
            image.SetActive(true);
        }
    }
}
