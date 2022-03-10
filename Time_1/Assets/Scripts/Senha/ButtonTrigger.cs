using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTrigger : MonoBehaviour
{
    public int ingredientNumber;
    public BoardSenha boardScript;

    private void OnMouseDown()
    {
        boardScript.AddIngrediente(ingredientNumber-1);
    }
}
