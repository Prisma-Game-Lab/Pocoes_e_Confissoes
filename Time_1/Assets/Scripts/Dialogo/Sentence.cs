using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sentence {

	public enum Speaker {Player, Cliente}
	public Speaker speaker;
	public string name;

	[TextArea(5, 10)]
	public string text;

}