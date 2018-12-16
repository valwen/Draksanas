using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour {

    private Animator animator;
    private SummonManager summonManager;
    private FocusEnemies focusEnemies;
    public GameObject gameManager;
    private PlayerController playerController;

    public bool BirdSummon;
    public bool CatSummon;

    public bool magicSpell;
    public bool physicAttack;

    public float speedAnimator;

    // Use this for initialization
    void Start () {
        animator = GetComponent<Animator>();
        summonManager = gameManager.GetComponent<SummonManager>();
        focusEnemies = gameManager.GetComponent<FocusEnemies>();
        playerController = gameManager.GetComponent<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {

        
        if (summonManager.summonBird)
        {
            BirdSummon = true;
            CatSummon = false;
            
        }
        else if (!summonManager.summonBird)
        {
            BirdSummon = false;
            CatSummon = true;
        }

        if (BirdSummon && focusEnemies.focus != null)
        {
            animator.SetBool("PhysicAttack", physicAttack = false);
            animator.SetBool("MagicSpell", magicSpell = true);
            Debug.Log("MAGIC");

            if (true)
            {

            }

        }

        if (CatSummon && focusEnemies.focus != null)
        {
            animator.SetBool("MagicSpell", magicSpell = false);
            animator.SetBool("PhysicAttack", physicAttack = true);

            Debug.Log("ATTACK");

            if (true)
            {

            }

        }


       //speedAnimator = playerController.speed;
       //animator.SetFloat("Speed", speedAnimator);



    }
}
