using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Choper la camera, multiplier par la normale du forward de la caméra (une unité dans la direction vecteur pos  - destination)
    void Update()

    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
    }
}