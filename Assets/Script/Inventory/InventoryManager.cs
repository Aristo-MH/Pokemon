using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventorySlot> slots;

    public static InventoryManager Instance;

    public List<string> catchedPokemon;

    void Awake()
    {
        if (Instance == null)
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
        ShowItem();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool AddItem(SOItem isItem)
    {
        bool isItemAdded = false;
        Debug.Log("isItem");
        foreach (var slot in slots)
        {
            if (slot.item == null)
            {
                slot.item = isItem;
                ShowItem();
                isItemAdded = true;
                break;
            }
        }
        return isItemAdded;
    }

    void ShowItem()
    {
        int jumlahPokeball = 0;
        foreach(var slot in slots)
        {
            if(slot.item == null)
            {
                slot.icon.sprite = null;
                slot.quantity = 0;
                slot.icon.gameObject.SetActive(false);
            }
            else
            {
                slot.icon.sprite = slot.item.gambar;
                slot.quantity = 1;
                slot.icon.gameObject.SetActive(true);
                if(slot.item.name == "Pokeball")
                {
                    jumlahPokeball++;
                }
            }
        }
        PlayerPrefs.SetInt("Pokeball", jumlahPokeball);
        PlayerPrefs.Save();
    }
}
