using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardSenha : MonoBehaviour
{
    //[Header("Lista com Prefabs de Ingredientes")]
    //public GameObject[] ingredientes;

    /*[Header("Layout do Board")]
    public float primeiroX;
    public float primeiroY;

    private float atualX;
    private float atualY;
    private GameObject ingredienteAdd;

    //Numero total de ingredientes j� colocados nessa tentativa
    private int totalInLine;
    private int currentLine;*/

    [Header(" ")]
    //Vetores com os atributos do pedido
    private int totalIngredients;
    private int totalSolidos;
    private int totalLiquidos;
    private int[] bebida;
    public Client cliente;
    public Text texto;

    // Start is called before the first frame update
    void Start()
    {
        totalSolidos = 0;
        totalLiquidos = 0;
        totalIngredients = 0;

        bebida = new int[3];
        UpdateText();
        for (int i = 0; i < 3; i++)
        {
            bebida[i] = 0;
        }
    }

    public void AddIngrediente(int[] tipoIngrediente)
    {
        if (totalIngredients < 3)
        {
            if ((tipoIngrediente[0] == 0) && (totalLiquidos < 1)) {
                bebida[2] = tipoIngrediente[1];
                totalLiquidos = 1;
                totalIngredients++;
                Debug.Log(totalLiquidos);
            } else if ((tipoIngrediente[0] == 1) && (totalSolidos < 2))
            {
                bebida[totalSolidos] = tipoIngrediente[1];
                totalSolidos++;
                totalIngredients++;
                Debug.Log(totalSolidos);
            }

            UpdateText();
        }
    }

    private void UpdateText()
    {
        texto.text = bebida[0].ToString() + " - " + bebida[1].ToString() + " - " + bebida[2].ToString();
    }
    public void RemoveIngredient()
    {
        if (totalIngredients > 0)
        {

            totalSolidos = 0;
            totalLiquidos = 0;
            totalIngredients = 0;

            bebida = new int[3];
            UpdateText();
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

            texto.text = bebida[0].ToString() + " - " + bebida[1].ToString() + " - " + bebida[2].ToString()
                + " - " + resultado.ToString();
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
    }
}
