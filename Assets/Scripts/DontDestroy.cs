using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {
    private static bool created = false;
    public GameObject player;
    public GameObject UIitems;
    void Awake()
    {
        if (!created)
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(player);
            DontDestroyOnLoad(UIitems);
            created = true;

        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

