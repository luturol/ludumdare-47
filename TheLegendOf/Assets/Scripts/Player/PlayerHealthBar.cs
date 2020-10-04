using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    //Vida do Player
    [SerializeField]public float playerHealth;

    void Start()
    {
        playerHealth = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            playerHealth--;
        }
        if (playerHealth <= 0)
        {
            playerHealth = 0;
        }
    }
}
