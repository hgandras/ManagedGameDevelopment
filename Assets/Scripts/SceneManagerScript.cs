using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class SceneManagerSCript : MonoBehaviour
{
    public static SceneManagerSCript instance {  get; private set; }

    public void Awake()
    {
        if(instance==null)
            instance = this;
    }
}
