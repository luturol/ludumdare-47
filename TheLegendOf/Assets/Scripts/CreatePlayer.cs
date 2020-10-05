using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CreatePlayer : MonoBehaviour
{
    public List<CharacterDictionary> characters;
    
    // Start is called before the first frame update
    void Start()
    {
        var prefab = characters.FirstOrDefault(e => e.character == SceneLoader.currentCharacter).prefab;
        Instantiate(prefab, transform.position, Quaternion.identity);
    }
}
