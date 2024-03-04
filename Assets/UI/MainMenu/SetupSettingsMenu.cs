using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SetupSettingsMenu
{
    Button BIGBUTTON;

    public Action buttonAction { set => BIGBUTTON.clicked += value; }

    public SetupSettingsMenu(VisualElement root)
    {
        BIGBUTTON = root.Q<Button>("Button");
    }
}
