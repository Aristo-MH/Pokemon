using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public TMP_Text HPText;

    public int HP;

    public int level;

    public int attackPower;

    public AttackAnim attackAnim;

    public BattleManager battleManager;

    public Animator animator;

    public string name;

    public Slider HPBar;

    public List<RuntimeAnimatorController> controllers;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        HP = PlayerPrefs.GetInt("HP");
        attackPower = PlayerPrefs.GetInt("attackPower");
        name = PlayerPrefs.GetString("name");
        HPText.text = "HP: " + HP;
        if(controllers.Count > 0)
        {
            if(name == "Bulbasaur")
            {
                animator.runtimeAnimatorController = controllers[0];
            }
            else if(name == "Charmander")
            {
                animator.runtimeAnimatorController = controllers[1];
            }
            else
            {
                animator.runtimeAnimatorController = controllers[2];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack(Enemy player)
    {
        player.DecreaseHP(attackPower);
        attackAnim.ShakeEffect(player.gameObject, 1.5f);
    }

    public void DecreaseHP(int attackpower)
    {
        if(HP - attackPower <= 0)
        {
            battleManager.BattleOver();
            HPText.text = "HP: " + 0;
            HPBar.value = 0;
        }
        else
        {
            HP -= attackPower;
            HPText.text = "HP: " + HP;
            HPBar.value = HP;
        }
    }
}
