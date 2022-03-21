using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public int ingredientNumber;
    public BoardSenha boardScript;

    [Header("Atributos do Ingrediente")]
    public int[] atributos;

    public int tipoDeAcao;

    private void OnMouseDown()
    {
        if (tipoDeAcao == 1)
        {
            boardScript.AddIngrediente(atributos);

        } else if (tipoDeAcao == 2) {

            boardScript.RemoveLastIngredient();
        }
        
    }
}
