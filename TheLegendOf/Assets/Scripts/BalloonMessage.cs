using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BalloonMessage : MonoBehaviour
{
    public List<CharacterMessage> messages;
    public float timeBeforeDelete = 10f;        

    public TextMeshProUGUI  text;
    private float waitedTime = 0f;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {                
        waitedTime = timeBeforeDelete;
        text.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (waitedTime <= 0)
        {
            Destroy(gameObject);
        }

        waitedTime -= Time.deltaTime;
    }

    public void SetText(Characters characters)
    {
        text.text = messages.FirstOrDefault(e => e.character == characters).message;
    }
}
