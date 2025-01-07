using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    public GameObject objectPrefab; // Prefab of the object to spawn
    public Transform patrolLocation; // Location for the helicopter to patrol
    public float moveSpeed = 5f; // Speed at which the spawned object moves
    public float respawnDelay = 4f;
    private GameObject spawnedObject;

    void Start()
    {
        // Automatically spawn the first object at the start
        SpawnObject();
    }

    void Update()
    {
        if (spawnedObject == null && !IsInvoking("SpawnObject"))
        {
            Invoke("SpawnObject", respawnDelay);
        }
        // Move the spawned object toward the patrol location if it exists
        if (spawnedObject != null && patrolLocation != null)
        {
            MoveTowardsLocation();
        }
    }

    private void SpawnObject()
    {
        // Spawn the object if none exists
        if (spawnedObject == null && objectPrefab != null)
        {
            spawnedObject = Instantiate(objectPrefab, transform.position, Quaternion.identity);
        }
    }

    private void MoveTowardsLocation()
    {
        // Move the spawned object toward the patrol location
        Vector3 direction = (patrolLocation.position - spawnedObject.transform.position).normalized;
        spawnedObject.transform.position += direction * moveSpeed * Time.deltaTime;

        // Optionally: Add logic to stop moving when the destination is reached
        if (Vector3.Distance(spawnedObject.transform.position, patrolLocation.position) < 0.1f)
        {
            // Object has reached the destination

        }
    }
}
