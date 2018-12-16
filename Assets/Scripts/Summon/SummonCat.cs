using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonCat : SummonBehaviour {

    // Cette classe doit être abstraite

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Action()
    {
        base.Action();

        SayHello();
    }

    public override void Action2()
    {
        base.Action();

        Boum();
    }

    void SayHello()
    {
        print("Hello Miaou");
    }

    void Boum()
    {
        print("Boum");
    }
}
