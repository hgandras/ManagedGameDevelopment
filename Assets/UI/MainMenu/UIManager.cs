using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


//Idea for structure: https://www.youtube.com/watch?v=XWScKbnc8xo
public class UIManager : MonoBehaviour
{
    VisualElement root;
    VisualElement mainMenu;
    VisualElement settingsMenu;

    private void Awake()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        mainMenu = root.Q<VisualElement>("MainMenu");
        settingsMenu  = root.Q<VisualElement>("SettingsMenu");
        
        SetupMainMenu main = new SetupMainMenu(mainMenu);
        main.settingsButtonAction = OnOptionsClick;
        main.playButtonAction = OnStartClick;
        main.quitButtonAction = OnQuitCLick;

        SetupSettingsMenu settings = new SetupSettingsMenu(settingsMenu);
        settings.buttonAction = OnBackClick;
    }

    //Main menu functionalities
    public void OnStartClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnOptionsClick()
    {
        mainMenu.SetEnabled(false);
        mainMenu.style.display = DisplayStyle.None;

        settingsMenu.SetEnabled(true);
        settingsMenu.style.display = DisplayStyle.Flex;
    }

    public void OnQuitCLick()
    {
        Application.Quit();
    }

    //Settings functionalities
    public void OnBackClick()
    {

        settingsMenu.SetEnabled(false);
        settingsMenu.style.display = DisplayStyle.None;

        mainMenu.SetEnabled(true);
        mainMenu.style.display = DisplayStyle.Flex;
        
    }

}
