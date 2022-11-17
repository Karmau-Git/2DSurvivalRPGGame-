using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIController : MonoBehaviour
{
    public GameObject Menu;
    bool MenuStatus = true;
    private void Start()
    {
        Time.timeScale = 0;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            MenuStatus = !MenuStatus;
            Menu.SetActive(MenuStatus);

            if (MenuStatus == true)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
       
    }
    public void OnClickReturnButton()
    {
        SceneManager.LoadScene("StartScene");
    }
    public void OnClickExitButton()
    {
        Application.Quit();
    }
    public void OnClickReturnMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
