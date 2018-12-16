using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeWorld : MonoBehaviour {

    public GameObject world1;
    public GameObject world2;
    public GameObject world3;
    public GameObject world4;

    public GameObject worldSelected;
    public string nameWorldScene;

    public GameObject UIwindows;
    public bool showWindows = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (worldSelected == world1)
        {
            print("World 1");
            nameWorldScene = "World1";
            UIwindows.SetActive(true);
            showWindows = true;

        }
        else if (worldSelected == world2)
        {
            print("World 2");
            nameWorldScene = "World2";
            UIwindows.SetActive(true);
            showWindows = true;
        }
        else if (worldSelected == world3)
        {
            print("World 3");
            nameWorldScene = "World3";
            UIwindows.SetActive(true);
            showWindows = true;
        }
        else if (worldSelected == world4)
        {
            print("World 4");
            nameWorldScene = "World4";
            UIwindows.SetActive(true);
            showWindows = true;
        }

        if (showWindows)
        {
            worldSelected = null;
        }

    }

    public void GoToAnotherScene()
    {
        print("Go to " + nameWorldScene);
        SceneManager.LoadScene(nameWorldScene);
        
    }

    public void CloseWindows()
    {
        UIwindows.SetActive(false);
        
}
}
