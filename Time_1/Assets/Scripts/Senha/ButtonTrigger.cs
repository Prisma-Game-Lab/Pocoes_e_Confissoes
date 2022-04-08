using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum Consistencia { Solido, Liquido }

public class ButtonTrigger : MonoBehaviour
{
    public BoardSenha boardScript;

    public Order.Sabor sabor;
    public Consistencia tipo;
    public int tipoDeAcao;
    [HideInInspector]public int[] tipoIngrediente;

    private void Start()
    {
        tipoIngrediente = new int[2];
        switch (tipo)
        {
            case Consistencia.Liquido:
                tipoIngrediente[0] = 0;
                break;
            case Consistencia.Solido:
                tipoIngrediente[0] = 1;
                break;
            default:
                Debug.Log("Tipo nao encontrado");
                break;
        }

        switch (sabor)
        {
            case Order.Sabor.Picante:
                tipoIngrediente[1] = 0;
                break;
            case Order.Sabor.Refrescante:
                tipoIngrediente[1] = 1;
                break;
            case Order.Sabor.Amargo:
                tipoIngrediente[1] = 2;
                break;
            case Order.Sabor.Doce:
                tipoIngrediente[1] = 3;
                break;
            case Order.Sabor.Salgado:
                tipoIngrediente[1] = 4;
                break;
            default:
                Debug.Log("Sabor nao encontrado");
                break;
        }
    }

    public UnityEvent OnClick;
    private void OnMouseDown()
    {        
        if (FindObjectOfType<GameManager>().mouseOverUI)
            return;
        OnClick.Invoke();
        if (tipoDeAcao == 1)
        {
            boardScript.AddIngrediente(tipoIngrediente);
        } else if (tipoDeAcao == 2) {
            boardScript.RemoveIngredient();
        } else if (tipoDeAcao == 3) {
            boardScript.CheckRecipe();
        }
        
    }
}
