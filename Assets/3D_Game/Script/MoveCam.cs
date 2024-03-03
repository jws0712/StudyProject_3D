using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    public Transform CamPos;

    void Update()
    {
        transform.position = CamPos.position;
    }
}
