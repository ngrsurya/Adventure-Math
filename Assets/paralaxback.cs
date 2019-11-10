using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxback : MonoBehaviour
{
   
    private Transform cameramotor;
    public float speed;


    // Start is called before the first frame update
    void Start()
    {
        cameramotor = Camera.main.transform;
       

    }

    // Update is called once per frame
    void Update()
    {
      
        transform.position = new Vector2(cameramotor.position.x / speed, 0);

   
    }
}
