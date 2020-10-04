using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] objects;
    public List<Enemies> enemies;
    // Start is called before the first frame update
    void Start()
    {
        int rand = 0;
        if (enemies.Count == 0)
        {
            rand = Random.Range(0, objects.Length);
            InstantiateObject(objects[rand]);
        }
        else
        {
            var EnemiesWithoutPlayer = enemies.Where(e => e.character != SceneLoader.currentCharacter).ToList();
            rand = Random.Range(0, EnemiesWithoutPlayer.Count);
            InstantiateObject(EnemiesWithoutPlayer[rand].enemyPrefab);
        }

    }

    private void InstantiateObject(GameObject newObject)
    {
        Instantiate(newObject, transform.position, Quaternion.identity);
    }
}
