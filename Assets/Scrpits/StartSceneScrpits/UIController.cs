using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    [Header("-- Player Data --")]
    [SerializeField] PlayerData playerData;
    public void SwitchSceneMain()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void OnExitGame()
    {
        Application.Quit();
    }
    public void OnClickSave()
    {
        playerData.Save();
    }
    public void OnClickLoad()
    {
        playerData.Load();
    }
}
