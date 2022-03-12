using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public int ingredientNumber;
    public BoardSenha boardScript;

    [Header("Atributos do Ingrediente")]
    public int[] atributos;

    private void OnMouseDown()
    {
        boardScript.AddIngrediente(atributos);
    }
}
