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
    public int[] orderAtributes;
    public int numberOfAtributes;
    private int[] currentAtributes;
    private int totalIngredients;
    private int[][] lastAdded;
    public Text texto;

    // Start is called before the first frame update
    void Start()
    {
        /*atualX = primeiroX;
        atualY = primeiroY;
        totalInLine = 0;
        currentLine = 1;*/

        totalIngredients = 0;
        currentAtributes = new int[numberOfAtributes];

        lastAdded = new int[3][];
        lastAdded[0] = new int[numberOfAtributes];
        lastAdded[1] = new int[numberOfAtributes];
        lastAdded[2] = new int[numberOfAtributes];

        for (int i = 0; i < numberOfAtributes; i++)
        {
            currentAtributes[i] = 0;
        }
    }

    // Update is called once per frame
    /*void CalculatePosition()
    {
        //Quando a linha encher, o proximo ser� colocado na debaixo
        if (totalInLine >= 3)
        {
            totalInLine = 0;
            atualX = primeiroX;
            atualY -= 1.5f;
            currentLine++;

            if (currentLine == 6)
            {
                primeiroX = 6f;
                atualX = primeiroX;
                atualY = primeiroY;
            }
        }
        
    }*/

    public void AddIngrediente(int[] atributos)
    {
        /*CalculatePosition();
        ingredienteAdd = Instantiate(ingredientes[ingNumber], new Vector3(atualX, atualY, 0f), Quaternion.identity);
        totalInLine++;
        atualX += 1.5f;*/
        if (totalIngredients < 3)
        {
            for (int i = 0; i < numberOfAtributes; i++)
            {
                currentAtributes[i] += atributos[i];
                print(currentAtributes[i]);
            }

            lastAdded[totalIngredients] = atributos;

            texto.text = "Atributo1 = " + currentAtributes[0].ToString() + " ---- " +
                         "Atributo2 = " + currentAtributes[1].ToString() + " ---- " +
                         "Atributo3 = " + currentAtributes[2].ToString() + " ---- " +
                         "Atributo4 = " + currentAtributes[3].ToString() + " ---- ";

            totalIngredients++;
        }
        
    }

    public void RemoveLastIngredient()
    {
        if (totalIngredients > 0)
        {
            for (int i = 0; i < numberOfAtributes; i++)
            {
                currentAtributes[i] -= lastAdded[totalIngredients - 1][i];
            }

            texto.text = "Atributo1 = " + currentAtributes[0].ToString() + " ---- " +
                         "Atributo2 = " + currentAtributes[1].ToString() + " ---- " +
                         "Atributo3 = " + currentAtributes[2].ToString() + " ---- " +
                         "Atributo4 = " + currentAtributes[3].ToString() + " ---- ";

            lastAdded[totalIngredients - 1] = new int[numberOfAtributes];
            totalIngredients--;
        }
        
    }

    public void CheckRecipe()
    {
        if (totalIngredients < 3)
        {
            int restante = 3 - totalIngredients;
            texto.text = "Coloque mais " + restante.ToString() + " ingrediente(s)";
        } else {
            /* INSIRA CHECAGEM DO PEDIDO AQUI */
        }
    }
}
