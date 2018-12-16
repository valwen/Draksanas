using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWorld : MonoBehaviour
{
    public GameObject sceneManager;
    ChangeWorld changeWorld;
    public bool mouseOver = false;

    private void Start()
    {
        changeWorld = sceneManager.GetComponent<ChangeWorld>();
    }

    private void OnMouseOver()
    {
        mouseOver = true;
    }

    private void OnMouseDown()
    {
        if (mouseOver)
        {
            changeWorld.worldSelected = gameObject;
        }
    }
}