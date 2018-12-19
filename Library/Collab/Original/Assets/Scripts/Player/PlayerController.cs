using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    new public Transform camera;

    //Choper la camera, multiplier par la normale du forward de la caméra
    void Update()

    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        Vector3 cameraF =camera.forward.normalized;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}