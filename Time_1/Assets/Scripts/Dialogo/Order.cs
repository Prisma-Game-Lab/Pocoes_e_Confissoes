using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Order
{

    public enum Sabor {Picante, Refrescante, Amargo, Doce, Salgado};
    public Dialogue pedido;
    public Dialogue respostaPicante;
    public Dialogue respostaRefrescante;
    public Dialogue respostaAmargo;
    public Dialogue respostaDoce;
    public Dialogue respostaSalgado;
    public Dictionary<Sabor, Dialogue> dic;
    [HideInInspector] public Dialogue[] respostas;
    public void ConvertDialogue()
    {
        dic[Sabor.Picante] = respostaPicante;
        dic[Sabor.Refrescante] = respostaRefrescante;
        dic[Sabor.Amargo] = respostaAmargo;
        dic[Sabor.Doce] = respostaDoce;
        dic[Sabor.Salgado] = respostaSalgado;
    }


    
}
