using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MerchantShopping : MonoBehaviour
{

    public GameObject shoppingUI;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collisionObject)
    {
        if (collisionObject.tag == "Player")
        {
            Debug.Log("Le marchand est prêt");
            //Inventory.instance.Add(potM);
            //Inventory.instance.Add(potH);
            shoppingUI.SetActive(!shoppingUI.activeSelf);
        }
    }
}
