using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {
        
    public float radius = 3f;

    GameObject player;

    public bool hasInteracted = false;





    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (Input.GetButtonDown("PickUp"))
        {
            if (!hasInteracted)
            {
                float distance = Vector3.Distance(player.transform.position, transform.position);
                if (distance <= radius)
                {
                    Interact();
                    hasInteracted = true;
                }
            }
        }
        
    }

    public void OnFocused()
    {

        hasInteracted = false;
    }

    public void OnDefocused()
    {

        hasInteracted = false;

    }


    // This method is meant to be overwritten
    public virtual void Interact()
    {
       
        Debug.Log("Interacting with " + transform.name);
    }


    // To change gizmos
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
    


}
