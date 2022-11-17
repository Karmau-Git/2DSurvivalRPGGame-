using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HPEXPController : MonoBehaviour
{
    public Image HP_image;
    public Image MP_image;
    public Image EXP_image;
    private void Update()
    {
        HP_image.fillAmount = Player.instance.HP / 100f ;
        MP_image.fillAmount = Player.instance.MP / 100f;
        EXP_image.fillAmount = Player.instance.EXP / 100f;
    }
}
