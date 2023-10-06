using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction
{
    public string characterName;
    public string text;
    public Sprite sprite;
}

public class Dialog : MonoBehaviour
{
    public List<Interaction> interactions;
}
