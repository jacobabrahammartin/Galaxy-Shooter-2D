using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    //speed variable of 8
    private float speed = 8.0f;

 

    // Update is called once per frame
    void Update()
    {
        //translate lazer up
         transform.Translate(Vector3.up * speed * Time.deltaTime);


         //if lazer position is greater than 8 on th ey
         //destroy the object
         if(transform.position.y > 8f)
         {
            Destroy(this.gameObject);
         }

       
    }
}
