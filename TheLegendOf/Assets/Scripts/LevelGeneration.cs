using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] objects;
    public List<Enemies> enemies;
    public float maxRangeOfTime = 7f;

    public float minRangeOfTime = 1f;
    private float spawnIn;
    private float timeWaitedToSpawn;
    private bool spawned = false;
    private int random = 0;
    // Start is called before the first frame update
    void Start()
    {
        if (enemies.Count == 0)
        {
            random = Random.Range(0, objects.Length);
            InstantiateObject(objects[random]);
        }
        else
        {
            spawnIn = Random.Range(minRangeOfTime, maxRangeOfTime);
            timeWaitedToSpawn = spawnIn;            
        }

    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (enemies.Count > 0 && !spawned)
        {
            if (timeWaitedToSpawn <= 0)
            {       
                Debug.Log(spawnIn);
                InstantiateEnemy();
                spawned = true;
                FindObjectOfType<Door>().AddEnemy();
            }
            else
            {
                timeWaitedToSpawn -= Time.deltaTime;
            }
        }
    }

    private void InstantiateEnemy()
    {
        var EnemiesWithoutPlayer = enemies.Where(e => e.character != SceneLoader.currentCharacter).ToList();
        random = Random.Range(0, EnemiesWithoutPlayer.Count);     
        var enemy = EnemiesWithoutPlayer[random];
        var prefab = Instantiate(enemy.enemyPrefab, transform.position, Quaternion.identity);
        prefab.GetComponent<Enemy>().SetCharacter(enemy.character);
    }
    private void InstantiateObject(GameObject newObject)
    {
        Instantiate(newObject, transform.position, Quaternion.identity);
    }
}
