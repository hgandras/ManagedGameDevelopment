using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ItemController : MonoBehaviour
{
    private GameObject CurrentActiveMenu;

    Controls actions;
    InputAction click, mousePos;
    Vector2 mouseScreenPos;
    GameObject hitObject;
    bool isDragging;

    [SerializeField] float buttonDist;
    [SerializeField] GameObject mainMenu;
    InputAction back;

    Vector2 mouseWorldPos
    {
        get
        {
            return sceneCamera.ScreenToWorldPoint(mouseScreenPos);
        }
    }
    
    [SerializeField] Camera sceneCamera;

    void Awake()
    {
        actions = new Controls();

        click = actions.EvolveEditor.Press;
        mousePos = actions.EvolveEditor.Drag;
        back = actions.EvolveEditor.Back;   

        mousePos.performed += Drag;
        click.performed += Click;
        click.canceled += _ => { isDragging = false; };
        back.performed += BackToMain;
    }

    private void OnEnable()
    {
       // actions.Enable();
        click.Enable();
        mousePos.Enable();
        back.Enable();
    }

    private void OnDisable()
    {
        // actions.Disable();
        click.Disable();
        mousePos.Disable();
        back.Disable();
    }

    private void Drag(InputAction.CallbackContext context)
    {
        mouseScreenPos = context.ReadValue<Vector2>();
        // Debug.Log(mouseScreenPos);
    }

    private IEnumerator Dragging()
    {
        isDragging = true;
        while(isDragging)
        {
            hitObject.transform.position = mouseWorldPos;
            yield return null;
        }
    }

    private void Click(InputAction.CallbackContext context)
    {
        //Debug.Log("Clicked");
        Ray ray = sceneCamera.ScreenPointToRay(mouseScreenPos);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin,ray.direction);
        if (hit.collider)
        {
            hitObject = hit.collider.gameObject;
            //Debug.Log("Collider hit: "+ hitObject);
            StartCoroutine(Dragging());
        }
    }

    public void SetActiveMenu(GameObject menu)
    {
        if (menu.tag != "Menu")
            return;
        CurrentActiveMenu = menu;
    }

    private void BackToMain(InputAction.CallbackContext context)
    {
        if (CurrentActiveMenu != null) 
        {
            mainMenu.SetActive(true);
            CurrentActiveMenu.SetActive(false);
            CurrentActiveMenu = null;
        }
        else if(CurrentActiveMenu == null) 
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    

}
