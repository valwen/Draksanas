using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonBehaviour : MonoBehaviour {
    protected GameObject gameManager;

    protected GameObject focusEnemy
    {
            get
            {
                if (gameManager == null)
                {
                    return null;
                }
                else
                {
                    return gameManager.GetComponent<FocusEnemies>().focus;
                }
            }

        }

        public void OnEnable()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }

void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        

    }

    public virtual void Action()
    {

    }

    public virtual void Action2()
    {

    }

    public virtual void Action3()
    {

    }

    public virtual void Action4()
    {

    }
}
