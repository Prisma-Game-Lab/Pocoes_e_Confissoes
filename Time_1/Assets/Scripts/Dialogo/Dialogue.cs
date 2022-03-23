using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue{
	public List<Sentence> sentences;
	[HideInInspector] public int type;
}