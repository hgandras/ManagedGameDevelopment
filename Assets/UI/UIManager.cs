using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class UIManager : MonoBehaviour
{

    VisualElement root;
    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        root.Q<Button>("Play-button").clicked += OnStartClick;
        root.Q<Button>("Options-button").clicked += OnOptionsClick;
        root.Q<Button>("Quit-button").clicked += OnQuitCLick;
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnOptionsClick()
    {
        root.SetEnabled(false);
        root.style.display = DisplayStyle.None;
    }

    public void OnQuitCLick()
    {
        Application.Quit();
    }

}
