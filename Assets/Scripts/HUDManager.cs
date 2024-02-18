using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public void UpdateXPBar()
    {
        Transform progressBarTransform=transform.Find("ProgressBarBase").Find("ProgressBarFill");
        Image progressBar = progressBarTransform.GetComponent<Image>();
        progressBar.fillAmount = (float)GameManager.instance.lvlProgress/GameManager.instance.lvlMaxXP;
        TMP_Text text = progressBarTransform.Find("XPText").transform.GetComponent<TMP_Text>();
        text.text = GameManager.instance.lvlProgress.ToString() + "/" + GameManager.instance.lvlMaxXP.ToString();
    }

    public void UpdateHPBar()
    {
        Debug.Log(GameManager.instance.playerHP);
    }
}
