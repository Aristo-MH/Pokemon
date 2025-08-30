using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public CanvasGroup menu;

    public CanvasGroup panelInventory;

    public CanvasGroup panelMoney;

    public bool menuOpen;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        menuOpen = false;
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "PokemonMenuScene" 
        || SceneManager.GetActiveScene().name == "PokemonSelectionScene" 
        || SceneManager.GetActiveScene().name == "BattleScene") return;

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(menuOpen == false)
            {
                Show();
                Debug.Log("Menu Buka");
            }
            else if(menuOpen == true)
            {
                Hide();
                Debug.Log("Menu Tutup");
            }
        }
    }

    public void Hide()
    {
        menuOpen = false;
        menu.alpha = 0;
    }

    void Show()
    {
        menuOpen = true;
        menu.alpha = 1;
    }

    public void HideInventory()
    {
        panelInventory.alpha = 0;
        panelMoney.alpha = 0;
    }

    public void ShowInventory()
    {
        panelInventory.alpha = 1;
        panelMoney.alpha = 1;
    }
}
