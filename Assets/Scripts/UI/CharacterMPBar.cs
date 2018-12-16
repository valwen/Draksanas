using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterMPBar : MonoBehaviour {


    public float magicMax;
    public float magicPoints;
    Image magicBar;

    private PlayerAbilities playerAbilities;
    GameObject player;

    // Use this for initialization
    void Start () {
        magicBar = GetComponent<Image>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerAbilities = player.GetComponent<PlayerAbilities>();

    }
	
	// Update is called once per frame
	void Update () {
        magicMax = playerAbilities.playerMaxMP;
        magicPoints = playerAbilities.playerCurrentMP;
        magicBar.fillAmount = magicPoints / magicMax;
    }
}
