using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectEvent : BaseGameEvent
{
    public GameObject objectToSpawn;
    public int spawnCount = 10;

    public float spawnRadius = 3f;

    public override void TriggerEvent(GameObject eventTarget)
    {
        var spawnedObjects = new List<GameObject>();
        for (int i = 0; i < spawnCount; i++)
        {
            var spawnPositionOffset = new Vector3(Random.Range(-spawnRadius, spawnRadius), 3, Random.Range(-spawnRadius , spawnRadius));
            var spawnedObject = Instantiate(objectToSpawn, transform.position +spawnPositionOffset, transform.rotation);
            spawnedObjects.Add(spawnedObject);
        }
    }

  
}
