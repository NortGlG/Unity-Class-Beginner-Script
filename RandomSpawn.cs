using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawn : MonoBehaviour {
    public GameObject[] objectToSpawn;
    public float offset;
    public float timeToSpawn;
    
    private float timer;
    private void Start() {
        timer = 0;
    }
    private void Update() {
        timer += Time.deltaTime;
        if(timer >= timeToSpawn){
            timer = 0;
            SpawnObject();
        }
    }
    private void SpawnObject(){
        GameObject objectSpawn = objectToSpawn[Random.Range(0, objectToSpawn.Length)];
        float randomOffsetX = Random.Range(-offset, offset);
        float randomOffsetZ = Random.Range(-offset, offset);
        Vector3 spawnPosition = new Vector3(transform.position.x + randomOffsetX, transform.position.y, transform.position.z + randomOffsetZ);
        Instantiate(objectSpawn, spawnPosition, Quaternion.identity);
    }
}
