using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Nome do Cliente", menuName = "Cliente")]

public class Client : ScriptableObject
{
    public GameObject prefab;
    public List<Order> orders;
    private void OnValidate()
    {
        foreach(Order order in orders)
        {
            foreach(Sentence sentence in order.pedido.sentences)
            {
                switch (sentence.speaker)
                {
                    case Sentence.Speaker.Cliente:
                        sentence.name = this.name;
                        break;
                    case Sentence.Speaker.Player:
                        sentence.name = "Atendente";
                        break;
                    default:
                        sentence.name = "ERRO";
                        break;
                }
            }
            Dialogue[] respostas = new Dialogue[] {order.respostaAmargo, order.respostaPicante, order.respostaDoce, order.respostaRefrescante, order.respostaSalgado};
            for (int i = 0; i < respostas.Length; i++)
            {
                respostas[i].type = 1;
                foreach(Sentence sentence in respostas[i].sentences)
                {
                    switch (sentence.speaker)
                    {
                        case Sentence.Speaker.Cliente:
                            sentence.name = this.name;
                            break;
                        case Sentence.Speaker.Player:
                            sentence.name = "Atendente";
                            break;
                        default:
                            sentence.name = "ERRO";
                            break;
                    }
                }
            }
        }
    }
    public void TriggerPedido(int i)
	{
		FindObjectOfType<DialogueManager>().StartDialogue(orders[i].pedido);
	}

    public void TriggerResposta(int i, Order.Sabor s)
    {
        Dialogue d;
        switch (s)
        {
            case Order.Sabor.Picante:
                d = orders[i].respostaPicante;
                break;
            case Order.Sabor.Refrescante:
                d = orders[i].respostaRefrescante;
                break;
            case Order.Sabor.Amargo:
                d = orders[i].respostaAmargo;
                break;
            case Order.Sabor.Doce:
                d = orders[i].respostaDoce;
                break;
            case Order.Sabor.Salgado:
                d = orders[i].respostaSalgado;
                break;
            default:
                d = orders[i].respostaAmargo;
                break;

        }
        FindObjectOfType<DialogueManager>().StartDialogueDelayed(d);
    }
}
