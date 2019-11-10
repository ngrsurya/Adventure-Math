﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTranfrom : MonoBehaviour
{
    private GameObject player;
    public Vector3 offset;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

}
