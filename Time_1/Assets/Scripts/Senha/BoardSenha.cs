using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardSenha : MonoBehaviour
{
    [Header("Lista com Prefabs de Ingredientes")]
    public GameObject[] ingredientes;

    [Header("Layout do Board")]
    public float primeiroX;
    public float primeiroY;

    private float atualX;
    private float atualY;
    private GameObject ingredienteAdd;

    //Numero total de ingredientes j� colocados nessa tentativa
    private int totalInLine;
    private int currentLine;

    // Start is called before the first frame update
    void Start()
    {
        atualX = primeiroX;
        atualY = primeiroY;
        totalInLine = 0;
        currentLine = 1;
    }

    // Update is called once per frame
    void CalculatePosition()
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
        
    }

    public void AddIngrediente(int ingNumber)
    {
        CalculatePosition();
        ingredienteAdd = Instantiate(ingredientes[ingNumber], new Vector3(atualX, atualY, 0f), Quaternion.identity);
        totalInLine++;
        atualX += 1.5f;
    }
}
