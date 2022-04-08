using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardSenha : MonoBehaviour
{
    private int totalIngredients;
    private int totalSolidos;
    private int totalLiquidos;
    private int[] bebida;
    public Client cliente;
    public Text texto;
    public GameObject botao;
    public GameObject dot;
    public List<GameObject> dots;

    void Start()
    {
        dots = new List<GameObject>();
        totalSolidos = 0;
        totalLiquidos = 0;
        totalIngredients = 0;
        botao.SetActive(false);

        bebida = new int[3];
        UpdateText();
        for (int i = 0; i < 3; i++)
        {
            bebida[i] = 0;
        }
    }

    public void AddIngrediente(int[] tipoIngrediente, GameObject ingredient)
    {
        if (totalIngredients < 3)
        {
            if ((tipoIngrediente[0] == 0) && (totalLiquidos < 1)) 
            {
                var new_dot = Instantiate(dot, new Vector3(ingredient.transform.position.x, -2.24f, 1),  ingredient.transform.rotation, this.transform);
                dots.Add(new_dot);
                bebida[2] = tipoIngrediente[1];
                totalLiquidos = 1;
                totalIngredients++;
                Debug.Log(totalLiquidos);
            } else if ((tipoIngrediente[0] == 1) && (totalSolidos < 2))
            {
                var new_dot = Instantiate(dot, new Vector3(ingredient.transform.position.x, 0.665f, 1),  ingredient.transform.rotation, this.transform);
                dots.Add(new_dot);
                bebida[totalSolidos] = tipoIngrediente[1];
                totalSolidos++;
                totalIngredients++;
                Debug.Log(totalSolidos);
            }

            UpdateText();
            if (totalIngredients == 3) { botao.SetActive(true); }
        }
    }

    private void UpdateText()
    {
        string parte1 = "";
        string parte2 = "";

        int restante = 3 - totalIngredients;
        if (restante > 0) {
            parte1 = "Coloque mais " + restante.ToString() + " ingredientes:\n";
        }

        restante = 1 - totalLiquidos;
        if (restante > 0) {
            parte2 = parte2 + restante.ToString() + " líquido\n";
        }

        restante = 2 - totalSolidos;
        if (restante > 0){
            parte2 = parte2 + restante.ToString() + " sólido(s)";
        }

        texto.text = parte1 + parte2;
    }
    public void RemoveIngredient()
    {
        if (totalIngredients > 0)
        {
            foreach (GameObject dot in dots)
            {
                Destroy(dot);
            }
            dots.Clear();

            totalSolidos = 0;
            totalLiquidos = 0;
            totalIngredients = 0;

            bebida = new int[3];
            UpdateText();
            botao.SetActive(false);
        }
        
    }

    public void CheckRecipe()
    {
        int resultado;

        if (totalIngredients < 3)
        {
            int restante = 3 - totalIngredients;
            texto.text = "Coloque mais " + restante.ToString() + " ingrediente(s)";
            return;
        } else {
            if ((bebida[0] == bebida[1]) || (bebida[0] == bebida[2]))
            {
                resultado = bebida[0];
            } else if (bebida[1] == bebida[2]) {
                resultado = bebida[1];
            } else {
                resultado = bebida[2];
            }

            //texto.text = bebida[0].ToString() + " - " + bebida[1].ToString() + " - " + bebida[2].ToString()
                //+ " - " + resultado.ToString();
        }

        switch (resultado)
        {
            case 0:
                cliente.TriggerResposta(0,Order.Sabor.Picante);
                break;
            case 1:
                cliente.TriggerResposta(0,Order.Sabor.Refrescante);
                break;
            case 2:
                cliente.TriggerResposta(0,Order.Sabor.Amargo);
                break;
            case 3:
                cliente.TriggerResposta(0,Order.Sabor.Doce);
                break;
            case 4:
                cliente.TriggerResposta(0,Order.Sabor.Salgado);
                break;
            default:
                Debug.Log("Sabor nao encontrado");
                break;
        }

        RemoveIngredient();
        if (!FindObjectOfType<GameManager>().screen)
        FindObjectOfType<GameManager>().SwitchScreen();
        FindObjectOfType<GameManager>().orderPlaced = false;
        FindObjectOfType<GameManager>().delivered = true;
        FindObjectOfType<GameManager>().button.SetActive(false);
    }
    
}
