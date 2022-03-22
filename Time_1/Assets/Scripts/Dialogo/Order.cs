using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Order
{

    public enum Sabor {Picante, Refrescante, Amargo, Doce, Salgado};
    public Dialogue pedido;
    public List<Sabor> sabores;
    public Dialogue[] respostas;
}
