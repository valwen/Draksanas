using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Focus : Interactable {
    
    private Color startColor;

    public Camera cam;
    public Interactable focus;


    void Update()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
            // We create a ray
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // If the ray hits

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null)
                {
                        SetFocus(interactable);
                }
            }
        //}
        else
        {
            RemoveFocus();
        }

        //if (Input.GetMouseButtonUp(0))
        //{
            // RemoveFocus();
        //}

    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }
            
            focus = newFocus;
        }
        
        newFocus.OnFocused();

    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.OnDefocused();
        }
        
        focus = null;
    }


}
