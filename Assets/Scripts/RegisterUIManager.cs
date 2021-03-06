﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RegisterUIManager : MonoBehaviour
{
    [SerializeField] private Image terminal = null;
    [SerializeField] private InputField inputField = null;
    [SerializeField] private Button nextButton = null;
    [SerializeField] private RegisteStory registeStory = null;
    [SerializeField] private DialogController dialogController = null;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// 터미널 이미지 활성화 및 Register 장면에 맞는 멘트 출력 함수 호출
    /// </summary>
    public void ActiveTerminal()
    {
        terminal.gameObject.SetActive(true);
        registeStory.FirstMent(dialogController);
    }

    public void NextButton(bool value)
    {
        nextButton.gameObject.SetActive(value);
    }

    public void RegisterStory()
    {
        registeStory.Registered(dialogController);
    }

    public void AppearInput()
    {
        inputField.gameObject.SetActive(true);
    }

    public void InputName()
    {
        if (inputField.text.Length <= 0)
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "이름을 입력해주세요!");
        else if (inputField.text.Length > 10)
        {
            dialogController.ShowTexts(0.5f, 1.5f, 0.02f, "이름을 10자 이내로 입력해주세요!");
            inputField.text = "";
        }
        else
        {
            GameManager.instance.SetName(inputField.text);
            inputField.gameObject.SetActive(false);
            RegisterStory();
        }
    }

    public void NextScene()
    {
        SceneManager.LoadScene("DailyScene");
    }
}
