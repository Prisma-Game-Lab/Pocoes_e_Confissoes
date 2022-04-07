using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "GameStateManager", menuName = "GameStateManager")]
public class GameStateManager : ScriptableSingleton<GameStateManager>
{
    public bool completed;
    public int currentClient;
    public List<int> order;

    private void Awake()
    {
        if (PlayerPrefs.HasKey("currentClient"))
        {
            currentClient = PlayerPrefs.GetInt("currentClient");
        }
        else
        {
            currentClient = -1;
            PlayerPrefs.SetInt("currentClient", currentClient);
        }
        if (PlayerPrefs.HasKey("order"))
        {
            order = new List<int>();
            string[] orderString = PlayerPrefs.GetString("order").Split(',');
            foreach (string s in orderString)
            {
                order.Add(int.Parse(s));
            }
        }
        else
        {
            order = new List<int>();
            PlayerPrefs.SetString("order", "");
        }
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("currentClient", currentClient);
        string orderString = "";
        foreach (int i in order)
        {
            orderString += i + ",";
        }
        PlayerPrefs.SetString("order", orderString);
    }

    public void ResetValues()
    {
        currentClient = -1;
        order = new List<int>();
        completed = false;
        SaveGame();
        SceneManager.LoadScene(0);
    }

    private void OnValidate()
    {
        currentClient = -1;
    }

}
