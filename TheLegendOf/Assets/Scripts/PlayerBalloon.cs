using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBalloon : MonoBehaviour
{
    [SerializeField] GameObject balloonPrefab;

    void Start()
    {
        Vector2 balloonPosition = new Vector2(transform.position.x, transform.position.y);
        Debug.Log("Balloon point: " + transform.position);
        Debug.Log("Expected balloon position: " + balloonPosition);
        var balloon = Instantiate(balloonPrefab, balloonPosition, Quaternion.identity);
        balloon.GetComponent<BalloonMessage>().SetText(SceneLoader.currentCharacter);
        var canvas = GameObject.FindGameObjectWithTag("UI");
        //balloon.transform.SetParent(canvas.transform, false);
        Debug.Log("Actual Position: " + balloon.transform.position);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
