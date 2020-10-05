using System.Threading;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class CharacterChangeMenu : MonoBehaviour
{
    public List<CharacterDictionary> characters;
    [SerializeField] Image characterImage;
    [SerializeField] Text characterText;
        
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {        
        characterImage.sprite = characters.FirstOrDefault(e => e.character == SceneLoader.currentCharacter).sprite;
        characterText.text = SceneLoader.currentCharacter.ToString();
    }
}
