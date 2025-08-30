using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleManager : MonoBehaviour
{
    public Enemy enemy;

    public Enemy player;

    BattleState currentBattleState;

    public bool action;

    public string namaPokemon;

    public Animator controllerPlayer;

    public List<Pokemon> pokemon;

    public Pokemon selectedPokemon;

    public int jumlahPokeball;

    enum BattleState
    {
        PlayerTurn,
        EnemyTurn,
        BattleOver
    }

    // Start is called before the first frame update
    void Start()
    {
        jumlahPokeball = PlayerPrefs.GetInt("Pokeball",0);
        currentBattleState = BattleState.PlayerTurn;
        action = true;
        namaPokemon = PlayerPrefs.GetString("Player");
        foreach(var currentPokemon in pokemon)
        {
            if(currentPokemon.nama == namaPokemon)
            {
                controllerPlayer.runtimeAnimatorController = currentPokemon.controller;
                selectedPokemon = currentPokemon;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Attack()
    {
        if(action == true)
        {
            action = false;
            if(currentBattleState == BattleState.PlayerTurn)
            {
                Debug.Log("PlayerAttack");
                player.Attack(enemy);
            }
            // StateChange();
            StartCoroutine(ChangeTurnDelay(1.5f));
        }
    }

    public void Run()
    {
        if(action == true)
        {
            action = false;
            if(currentBattleState == BattleState.PlayerTurn)
            {
                Debug.Log("PlayerRun");
                bool runSuccess = false;
                int Chance = Random.Range(1, 3);
                if(Chance == 1)
                {
                    runSuccess = false;
                    Debug.Log("Gagal");
                }
                else
                {
                    runSuccess = true;
                    Debug.Log("Berhasil");
                    BattleOver();
                }
                // StateChange();
                StartCoroutine(ChangeTurnDelay(1.5f));
            }
        }
    }

    public void Catch()
    {
        if(jumlahPokeball <= 0)
        {
            Debug.Log("Tidak punya pokeball");
            StartCoroutine(ChangeTurnDelay(1.5f));
            return;
        }
        bool isCatched = false;
        int catchChance = Random.Range(1, 5);
        if(catchChance == 1 || catchChance == 2)
        {
            isCatched = true;
            InventoryManager.Instance.catchedPokemon.Add(enemy.name);
            BattleOver();
        }
        Debug.Log(isCatched);
        StartCoroutine(ChangeTurnDelay(1.5f));
        return;
    }

    public void StateChange()
    {
        if(currentBattleState == BattleState.PlayerTurn)
        {
            currentBattleState = BattleState.EnemyTurn;
            enemy.Attack(player);
        }
        if(currentBattleState == BattleState.EnemyTurn)
        {
            currentBattleState = BattleState.PlayerTurn;
            action = true;
        }
    }

    public void BattleOver()
    {
        currentBattleState = BattleState.BattleOver;
        Debug.Log("BattleOver");
        selectedPokemon.exp += 10;
        SceneLoader.Instance.LoadScene("Demo Scene");
    }

    IEnumerator ChangeTurnDelay(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        StateChange();
    }
}
