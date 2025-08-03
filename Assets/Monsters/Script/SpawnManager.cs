using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<Transform> spawner;

    public List<GameObject> monsters;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", 2.5f, 2.5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int indexLokasi = Random.Range(0,spawner.Count);
        int index = Random.Range(0,monsters.Count);
        GameObject obj = Instantiate(monsters[index], spawner[indexLokasi].position, Quaternion.identity);
        Debug.Log("spawn");
    }
}
