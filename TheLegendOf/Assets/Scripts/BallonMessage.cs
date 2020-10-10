using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class BallonMessage : MonoBehaviour
{
    public List<CharacterMessage> messages;        
    
    private Text text;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void SetText(Characters characters)
    {
         text.text = messages.FirstOrDefault(e => e.character == characters).message;
    }
}
