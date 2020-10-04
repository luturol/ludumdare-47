using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChangeMenu : MonoBehaviour
{
    public CharacterDictionary[] characters;
    [SerializeField] Image image;
        
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {        
        image.sprite = characters[(int) SceneLoader.currentCharacter].sprite;
    }
}
