using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonBird : SummonBehaviour {

    // Cette classe doit être abstraite

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Action()
    {
        base.Action();

        SayHello();
    }

    public override void Action2()
    {
        base.Action();

        Fire();
    }

    void SayHello()
    {
        print("Hello Piou");
    }

    void Fire()
    {
        if (focusEnemy != null && focusEnemy != null)
        {
            GameObject cible = focusEnemy.gameObject;
            if (cible.CompareTag("Enemy"))
            {
                EnemyBehaviour enemyBehaviour = cible.GetComponent<EnemyBehaviour>();
                enemyBehaviour.enemyHP -= 100;
            }
        }
    }
}
