using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HUDManager : MonoBehaviour
{

    VisualElement root;
    ProgressBar XPBar;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        XPBar = root.Q<ProgressBar>("XPbar");
        UpdateXPBar();
    }

    public void UpdateXPBar()
    {
        XPBar.title = "50/100";
        XPBar.value = 50f;
    }
}
