using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOPokemon", menuName = "Scriptable Objects/SOPokemon")]
public class Pokemon : ScriptableObject
{
    public RuntimeAnimatorController controller;

    public string nama;

    public int exp;

    public int level;

    public int attack;

    public int HP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
