using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PokemonSelection : MonoBehaviour
{
    public List<RuntimeAnimatorController> pokemon;

    public Animator animator;

    public int index;

    public TMP_Text nama;

    public List<Pokemon> pokmon;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        // animator.runtimeAnimatorController = pokemon[index];
        nama.text = pokmon[index].nama;
        animator.runtimeAnimatorController = pokmon[index].controller;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Next()
    {
        int tmp = index;

        if((tmp += 1) > pokmon.Count - 1)
        {
            index = 0;
        }
        else
        {
            index += 1;
        }
        // animator.runtimeAnimatorController = pokemon[index];
        nama.text = pokmon[index].nama;
        animator.runtimeAnimatorController = pokmon[index].controller;
    }

    public void Previous()
    {
        int tmp = index;

        if((tmp -= 1) < 0)
        {
            index = pokmon.Count - 1;
        }
        else
        {
            index -= 1;
        }
        // animator.runtimeAnimatorController = pokemon[index];
        nama.text = pokmon[index].nama;
        animator.runtimeAnimatorController = pokmon[index].controller;
    }

    public void Select()
    {
        PlayerPrefs.SetString("Player", pokmon[index].nama);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Demo Scene");
    }
}
