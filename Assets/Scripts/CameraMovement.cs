using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float smoothTime = 0.25f;
    private Vector3 v=Vector3.zero;
    [SerializeField] private GameObject objToFollow;

    private void FixedUpdate()
    {
        Vector3 targetPos=objToFollow.transform.position;
         targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position,targetPos,ref v,smoothTime);
    }

    
}
