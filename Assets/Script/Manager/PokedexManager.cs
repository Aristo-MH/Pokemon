using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PokedexManager : MonoBehaviour
{
    public List<Pokemon> pokmon;

    public TMP_Text nama;

    public TMP_Text HP;

    public TMP_Text attackPower;

    public Animator animator;

    public List<RuntimeAnimatorController> gambar;

    int index = 0;

    // Start is called before the first frame update
    void Start()
    {
        if(InventoryManager.Instance.catchedPokemon.Count > 0)
        {
            foreach (Pokemon data in pokmon)
            {
                if(data != null)
                {
                    if(data.nama == InventoryManager.Instance.catchedPokemon[index])
                    {
                        nama.text = data.nama;
                        attackPower.text = data.attack.ToString();
                        HP.text = data.HP.ToString();
                        animator.runtimeAnimatorController = pokmon[index].controller;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Back()
    {
        SceneLoader.Instance.LoadScene("Demo Scene");
    }
}
