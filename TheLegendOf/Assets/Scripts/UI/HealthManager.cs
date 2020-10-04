using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    [SerializeField] Image hpImage;
    [SerializeField] PlayerHealthBar playerHP;
    [SerializeField] Sprite[] health;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealthBar>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHP.playerHealth == 0)
        {
            hpImage.sprite = health[0];
        }
        if (playerHP.playerHealth == 1)
        {
            hpImage.sprite = health[1];
        }
        if (playerHP.playerHealth == 2)
        {
            hpImage.sprite = health[2];
        }
    }
}
