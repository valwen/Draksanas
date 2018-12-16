using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterLifeBar : MonoBehaviour
{


    public float lifeMax;
    public float lifePoints;
    Image lifeBar;

    private PlayerAbilities playerAbilities;
    GameObject player;

    // Use this for initialization
    void Start()
    {
        lifeBar = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAbilities = player.GetComponent<PlayerAbilities>();

    }

    // Update is called once per frame
    void Update()
    {
        lifeMax = playerAbilities.playerMaxHP;
        lifePoints = playerAbilities.playerCurrentHP;
        lifeBar.fillAmount = lifePoints / lifeMax;
    }
}
