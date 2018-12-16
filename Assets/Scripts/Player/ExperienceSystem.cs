using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceSystem : MonoBehaviour {

    public int experiencePoint;
    public int experiencePointTotal;
    public int experienceLvl = 1;
    public int experienceNextLvl = 1000;

	// Use this for initialization
	void Start () {

        experiencePoint = 0;
        GetComponent<PlayerAbilities>();

}
	
	// Update is called once per frame
	void Update () {
        NextLevel();
	}

    void NextLevel()
    {
        if (experiencePoint == experienceNextLvl)
        {
            experiencePoint = 0;
            experienceLvl++;
            experienceNextLvl += experienceNextLvl;
        }
    }
}
