using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public bool screen;
    public List<Client> clientes;
    public Dialogue startingDialogue;
    public Dialogue endingDialogue;
    [HideInInspector] public int currentClient;
    private GameObject temp = null;
    [HideInInspector] public bool orderPlaced;
    [HideInInspector] public bool delivered;
    [HideInInspector] public bool mouseOverUI;
    public GameObject board;
    public GameObject warning;
    [HideInInspector] public List<int> order;
    public GameObject button;
    public GameObject fadeIn;
    public GameObject fadeOut;

    private void Start()
    {
        if (GameStateManager.instance.order.Count == 0)
        {
            order = new List<int>();
            for (int i = 0; i < 3; i++)
            {
                order.Add(i);
            }
            order = Shuffle(order);
            GameStateManager.instance.order = order;

        }
        else
        {
            order = GameStateManager.instance.order;
        }

        screen = true;
        delivered = false;
        orderPlaced = false;
        button.SetActive(false);
        currentClient = (GameStateManager.instance.currentClient == -1)? -1 : GameStateManager.instance.currentClient - 1;
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
        GameStateManager.instance.currentClient = ++currentClient;
        GameStateManager.instance.SaveGame();
        
        if (temp != null)
        {
            Destroy(temp);
            temp = null;
        }

        if (currentClient >= clientes.Count)
        {
            FindObjectOfType<DialogueManager>().StopAllCoroutines();
            StartCoroutine(EndGame());
            return;
        }

        temp = Instantiate(clientes[order[currentClient]].prefab);
        FindObjectOfType<BoardSenha>().cliente = clientes[order[currentClient]];      
        delivered = false;
    }

    public void PlayClient()
    {
        clientes[order[currentClient]].TriggerPedido(0);
        orderPlaced = true;
        button.SetActive(true);
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

    public IEnumerator EndGame()
    {
        yield return new WaitForSeconds(0.5f);
        FindObjectOfType<DialogueManager>().StartDialogue(endingDialogue);
        yield return new WaitForSeconds(2);
        var fade = Instantiate(fadeOut);
        yield return new WaitForSeconds(fade.GetComponent<FadeObject>().duration);
        GameStateManager.instance.completed = true;
        SceneManager.LoadScene(0);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
