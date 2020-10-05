using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum Characters
{
    Gladiator = 0,
    Witcher = 1,
    Archer = 2,
    
}

[Serializable]

public class CharacterDictionary
{
    public Characters character;
    public Sprite sprite;
    public GameObject prefab;
}