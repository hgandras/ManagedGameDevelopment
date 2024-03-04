using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SetupMainMenu
{

    Button playButton;
    Button settingsButton;
    Button quitButton;

    public Action playButtonAction { set => playButton.clicked += value; }
    public Action settingsButtonAction { set => settingsButton.clicked += value; }
    public Action quitButtonAction { set => quitButton.clicked += value; }

    public SetupMainMenu(VisualElement root)
    {
        playButton = root.Q<Button>("Play-button");
        settingsButton = root.Q<Button>("Options-button");
        quitButton = root.Q<Button>("Quit-button");
    }

    
}
