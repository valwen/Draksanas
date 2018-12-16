using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shopping : MonoBehaviour {


    public Item PotionMP;
    public Item PotionHP;
    public GameObject shoppingUI;
    public Inventory inventory;
    public GameObject gameManager;
    public int coins;


    private void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        inventory = gameManager.GetComponent<Inventory>();
        coins = inventory.coins;

    }

    private void Update()
    {
        print(coins);
    }

    public void BuyItemPotionMP()
    {
        if (coins >= 10)
        {
            coins -= 10;
            Inventory.instance.Add(PotionMP);
        }



    }

    public void BuyItemPotionHP()
    {
        Inventory.instance.Add(PotionHP);

    }

    public void CloseWindow()
    {
        shoppingUI.SetActive(false);
    }


}
