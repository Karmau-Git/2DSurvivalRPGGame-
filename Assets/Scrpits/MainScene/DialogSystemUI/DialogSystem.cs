using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour 
{
    [Header("UI组件")]
    public TextMeshProUGUI textLabel;
    public Image faceImage;
    [Header("文本文件")]
    public TextAsset textFile1,textFile2;
    int index=0;
    float textSpeed = 0.1f;
    bool textFinished;
    [Header("头像")]
    public Sprite face01,face02,face03;
    public GameObject button;
    int a = 0;
    int indexNpc ;
    E_ButtonUI SelectNpc;
    List<string> textList = new List<string>();

    // Start is called before the first frame update
    void Awake()
    {
        indexNpc = 0;
        GetTextFormFile(textFile1);
    }
    private void OnEnable()
    {
        if (indexNpc ==1)
        {
            GetTextFormFile(textFile2);
        }
        textFinished = true;
        //textLabel.text = textList[index];
        //index++;
        //StartCoroutine(SetTextUI());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && index == textList.Count )
        {
            index = 0;
            indexNpc += 1;
            gameObject.SetActive(false);
            return; 
        }
        if (Input.GetKeyDown(KeyCode.E)&&textFinished)
        {
            //textLabel.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI());
        }
    }
    void GetTextFormFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach(var line in lineDate)
        {
            textList.Add(line);
        }
    }
    IEnumerator SetTextUI()
    {
        textFinished = false;
        textLabel.text = "";

        switch(textList[index].Trim())
        {
            case "A":
                faceImage.sprite = face01;
                index++;
                break; 
            case "B":
                faceImage.sprite = face02;
                index++;
                break;
            case "C":
                faceImage.sprite = face03;
                index++;
                break ;
        }
        for (int i = 0; i < textList[index].Length; i++)
        {
            textLabel.text += textList[index][i];
            yield return new WaitForSeconds(textSpeed);
        }
        textFinished = true;
        index++;
    }
}
