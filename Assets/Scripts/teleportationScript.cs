using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class teleportationScript : MonoBehaviour {
    public GameObject windowsLoadScene;
    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {

            windowsLoadScene.SetActive(true);

        }
    }

    public void CloseWindows()
    {
        windowsLoadScene.SetActive(false);
    }

    public void GoToAnotherScene()
    {
        windowsLoadScene.SetActive(false);
        SceneManager.LoadScene("WorldsScene");
    }
}
