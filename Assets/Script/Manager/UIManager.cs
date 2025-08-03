using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public CanvasGroup menu;

    public bool menuOpen;

    // Start is called before the first frame update
    void Start()
    {
        menuOpen = false;
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
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

    void Hide()
    {
        menuOpen = false;
        menu.alpha = 0;
    }

    void Show()
    {
        menuOpen = true;
        menu.alpha = 1;
    }
}
