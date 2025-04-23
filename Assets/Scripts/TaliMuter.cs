using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaliMuter : MonoBehaviour
{
    [SerializeField] float accel = 10f;
    public float rotSpeed = 100f;
    [SerializeField] float rotNumber = 0f;
    
    void Update()
    {
        float rotThisFrame = rotSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotThisFrame);
        rotNumber += rotThisFrame;
        //Debug.Log(totalRot);

        if (rotNumber >= 360f)
        {
            rotNumber -= 360f;
            rotSpeed += accel;
        }

    }
}
