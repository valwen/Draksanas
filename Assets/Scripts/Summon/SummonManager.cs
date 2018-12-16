using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonManager : MonoBehaviour {

    // Cette classe doit être abstraite

    public GameObject catObject;
    public GameObject birdObject;
    public bool summonOn = true;
    public bool summonCat ;
    public bool summonBird;
    public GameObject player;
    public SummonBehaviour currentSummon;


    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        catObject = GameObject.FindGameObjectWithTag("Cat");
        birdObject = GameObject.FindGameObjectWithTag("Bird");
        birdObject.SetActive(false);
        summonCat = true;
        currentSummon = catObject.GetComponent<SummonBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {

        // If you press "Tab" you summon the other creature
        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            Debug.Log("Tab was pressed.");
            SummonSwitch();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSummon.Action();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSummon.Action2();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSummon.Action3();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentSummon.Action4();
        }
    }

    // Switch between the summons : cat or bird
    void SummonSwitch()
    {
        if (!summonOn)
        {
            catObject.SetActive(true);
            birdObject.SetActive(false);
            summonOn = true;
            summonCat = true;
            summonBird = false;
            currentSummon = catObject.GetComponent<SummonBehaviour>();
        }

        else if (summonOn)
        {
            catObject.SetActive(false);
            birdObject.SetActive(true);
            summonOn = false;
            summonBird = true;
            summonCat = false;
            currentSummon = birdObject.GetComponent<SummonBehaviour>();
        }
    }

    
}
