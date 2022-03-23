using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public List<Client> clientes;
    [HideInInspector] public int currentClient;

    public bool mouseOverUI;

    public void StartGame()
    {
        AdvanceClient();
    }
    public void AdvanceClient()
    {
        FindObjectOfType<BoardSenha>().cliente = clientes[currentClient];
        clientes[currentClient++].TriggerPedido(0);
        
    }

}
