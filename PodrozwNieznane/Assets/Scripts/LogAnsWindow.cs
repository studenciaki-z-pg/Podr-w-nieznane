﻿using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class LogAnsWindow : MonoBehaviour
{
    [SerializeField] Text LogText;

    private StringBuilder stringBuilder = new StringBuilder();
    public int answer = -1;

    private void OnValidate()
    {
        gameObject.SetActive(false);
    }

    void HideLog()
    {
        gameObject.SetActive(false);
        GameManager.instance.hexGameUI.Highlighting(true);
        GameManager.instance.Interacting = false;
    }

    void ShowLog()
    {
        GameManager.instance.Interacting = true;
        GameManager.instance.hexGameUI.Highlighting(false);
        gameObject.SetActive(true);
    }

    public void SendLog(string s)
    {
        LogText.text = s;
        answer = -1;
        ShowLog();
    }

    public void YesAnswer()
    {
        answer = 1;
        HideLog();
    }

    public void NoAnswer()
    {
        answer = 0;
        HideLog();
    }
}
