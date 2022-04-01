using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool screen;
    public List<Client> clientes;
    public Dialogue startingDialogue;
    [HideInInspector] public int currentClient;
    private GameObject temp = null;
    private bool orderPlaced;
    [HideInInspector] public bool mouseOverUI;
    public GameObject board;
    public GameObject warning;
    public List<int> order;

    private void Start()
    {
        for (int i = 0; i < clientes.Count; i++)
        {
            order.Add(i);
        }
        order = Shuffle(order);
        screen = true;
        orderPlaced = false;
        currentClient = -1;
        StartCoroutine(StartDelayed(2));
    }
    public void StartGame()
    {
        PlayStartingText();
        AdvanceClient();
    }

    public void EndClient()
    {
        if (temp != null)
        {
            Destroy(temp);
            temp = null;
        }
  
    }
    public void AdvanceClient()
    {
        orderPlaced = false;
        currentClient++;
        if (temp != null)
        {
            Destroy(temp);
            temp = null;
        }

        if (currentClient >= clientes.Count)
        {
            Debug.Log("Fim do jogo");
            return;
        }

        temp = Instantiate(clientes[order[currentClient]].prefab);
        FindObjectOfType<BoardSenha>().cliente = clientes[order[currentClient]];      
    }

    public void PlayClient()
    {
        clientes[order[currentClient]].TriggerPedido(0);
        orderPlaced = true;
    }

    void PlayStartingText()
    {
        FindObjectOfType<DialogueManager>().StartDialogueDelayed(startingDialogue);
    }

    public IEnumerator StartDelayed(int time)
    {
        yield return new WaitForSeconds(time);
        StartGame();
    }

    public void SwitchScreen()
    {
        if (!temp || !orderPlaced)
        {
            StartCoroutine(OrderNotPlaced());
            return;
        }
        if (screen)
        {
            board.transform.position += new Vector3(-10, 0, 0);
            warning.SetActive(true);
            temp.transform.position = temp.transform.position + new Vector3(-5, 0, 0);
        }
        else
        {
            board.transform.position += new Vector3(10, 0, 0);
            warning.SetActive(false);
            temp.transform.position = temp.transform.position + new Vector3(5, 0, 0);
        }
        screen = !screen;
    }

    private IEnumerator OrderNotPlaced()
    {
        var txt = warning.transform.GetChild(0).gameObject.GetComponent<Text>();
        var originalText = txt.text;
        txt.text = "Nenhum Pedido foi feito!";
        warning.SetActive(true);
        yield return new WaitForSeconds(1);
        txt.text = originalText;
        warning.SetActive(false);
    }

    public List<int> Shuffle(List<int> _list)
    {
        for (int i = 0; i < _list.Count; i++)
        {
            var temp = _list[i];
            int randomIndex = Random.Range(i, _list.Count);
            _list[i] = _list[randomIndex];
            _list[randomIndex] = temp;
        }

        return _list;
    }
}
