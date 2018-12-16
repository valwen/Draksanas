using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleTime : MonoBehaviour
{


    public Renderer sky;
    public float scrollSpeed;
    float offsetCurrent;

    void Update()
    {

            offsetCurrent += scrollSpeed / 60;
            sky.material.SetTextureOffset("_MainTex", new Vector2(offsetCurrent, 0f));

    }
}
