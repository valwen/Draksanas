using UnityEngine.EventSystems;
using UnityEngine;


public class PlayerAbilities : MonoBehaviour {
    public float playerMaxHP = 100f;
    public float playerMaxMP = 200f;
    public float playerCurrentHP ;
    public float playerCurrentMP ;
    public float playerForce = 20;
    //public float playerDetection;

    public float time = 0f;
    public int regenSpeed = 1;

    
    
    private void Start()
    {
        playerCurrentHP = 50;
        playerCurrentMP = 50;
    }

    void Update () {
        //  Focus
        //if (EventSystem.current.IsPointerOverGameObject())
        //{
        //    return;
        //}


        if(regenSpeed > 0 && time > 0)
        {
            time -= Time.deltaTime;
            restoreHP(regenSpeed);
            restoreMP(regenSpeed);
        }
        else
        {
            restoreHP(1);
            restoreMP(1);
        }
        
        
	}


    // Method to restore HP and MP
    public void restoreHP(int speed)
    {
        if (playerCurrentHP < playerMaxHP)
        {
            float regenSpeed = speed * Time.deltaTime * 1;
            playerCurrentHP += (regenSpeed / 3);
        }
    }
    public void restoreMP( int speed)
    {
        if (playerCurrentMP < playerMaxMP)
        {
            float regenSpeed = speed * Time.deltaTime * 1;
            playerCurrentMP += regenSpeed;
        }
    }
}
