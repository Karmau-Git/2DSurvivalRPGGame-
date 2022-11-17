using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagUIController : MonoBehaviour
{
    public GameObject myBag;
    bool isOpen;
    
    private void Update()
    {
        OpenMyBag(); 
    }
    void OpenMyBag()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isOpen = !isOpen;
            myBag.SetActive(isOpen);

            if (isOpen == true)
            {
                Debug.Log("True");
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
