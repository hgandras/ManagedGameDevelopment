using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    private Controls actions;
    private InputAction backAction;

    private void OnEnable()
    {
        
        backAction.Enable();
    }

    private void OnDisable()
    {
        backAction.Disable();
    }

    private void Awake()
    {
        actions = new Controls();

        backAction = actions.Gameplay.Back;

        backAction.performed += ChangeToEditor; 
    }

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

    public void ChangeToEditor(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Change Scene");
        SceneManager.LoadScene("Editor");
    }
}
