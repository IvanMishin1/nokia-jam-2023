using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //A script that spawns falling objects (folders, viruses etc)

    public Controller controller;

    //Each class to contain each type of object and how often it spawns
    [System.Serializable]
    public class Types
    {
        public GameObject prefab;
        public float spawnRate;

    }

    //An array containing all the types.
    public Types[] fallingObjects;


    void Update()
    {
        
        foreach(Types type in fallingObjects)
        {
            if (Random.value < type.spawnRate * Time.deltaTime)
            {
                Spawn(type.prefab);
                
            }
        }
    }

    void Spawn(GameObject prefab)
    {
        Vector2 spawnPosition;
        spawnPosition.y = 50;
        spawnPosition.x = Random.Range(-13, 13);
        GameObject newObject = Instantiate(prefab,spawnPosition,Quaternion.identity);
        newObject.GetComponent<FallingObject>().controller = controller;

    }
}
