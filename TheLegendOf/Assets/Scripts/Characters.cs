using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public enum Characters
{
    Gladiator,
    Archer,
    Witcher
}

[Serializable]

public class CharacterDictionary
{
    public Characters character;
    public Sprite sprite;
}