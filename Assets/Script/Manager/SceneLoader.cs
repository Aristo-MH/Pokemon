using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

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
        if (SceneManager.GetActiveScene().name == "BaseScene")
        {
            SceneManager.LoadScene("Demo Scene", LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName("Demo Scene"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        if(sceneName == "Demo Scene")
        {
            UIManager.Instance.ShowInventory();
        }
        else if (sceneName == "Main Menu")
        {
            Debug.Log("Loading Main Menu");
            KeepAlive[] keepAliveObjects = FindObjectsByType<KeepAlive>(FindObjectsSortMode.None);
            foreach (KeepAlive obj in keepAliveObjects)
            {
                Destroy(obj.gameObject);
            }
        }
        else
        {
            UIManager.Instance.HideInventory();
        }
        SceneManager.LoadScene(sceneName);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("BaseScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
}
