using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearViewCameraScript : MonoBehaviour
{
    public Transform Car;
    float rotX, rotY, rotZ;

    void Start()
    {
        
    }

    void Update()
    {
        rotX = Car.eulerAngles.x;
        rotY = Car.eulerAngles.y;
        rotZ = Car.eulerAngles.z;

        transform.eulerAngles = new Vector3(rotX - rotX, rotY - 180, rotZ - rotZ);
    }
}
