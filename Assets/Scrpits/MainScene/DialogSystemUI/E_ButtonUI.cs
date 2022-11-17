using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class E_ButtonUI : MonoBehaviour
{
    public GameObject button;
    public GameObject talkUI;
    public GameObject dialog;
    int i=0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            dialog.SetActive(true);
            talkUI.SetActive(false);
            if (i != 1)
            {
                button.SetActive(true);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D other)
    {
        button.SetActive(false);
        
    }
    // Update is called once per frame
    void Update()
    {
        if(button.activeSelf && Input.GetKeyDown(KeyCode.E))
        {
            talkUI.SetActive(true);
            button.SetActive(false);
            i = 1;
        }
        
    }
}
