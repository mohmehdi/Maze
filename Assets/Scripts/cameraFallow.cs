using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFallow : MonoBehaviour
{
    public Vector3 offcet;
    public Transform mouse;
    void Update()
    {
        transform.position =Vector3.Lerp(transform.position, mouse.position + offcet,0.2f);
        //transform.position =  mouse.position + offcet;
    }
}
