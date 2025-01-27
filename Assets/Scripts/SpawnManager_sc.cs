using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_sc : MonoBehaviour
{
    bool stopSpawning = false;
    [SerializeField]
    GameObject[] CloudPrefabs; // Array of cloud prefabs to spawn

     // Coroutine to spawn clouds periodically
    IEnumerator SpawnCloudRoutine()
    {
        while (stopSpawning == false)
        {
            Vector3 position = new Vector3(10.0f, Random.Range(0f, 4.0f),0);
            // Randomly select a cloud prefab from the array  
            int randomCloud = Random.Range(0,2);    
            // Instantiate the selected cloud at the generated position        
            Instantiate(CloudPrefabs[randomCloud], position, Quaternion.identity);  
            yield return new WaitForSeconds(7.0f); 

        }
    }
    void Start()
    {
        // Start the coroutine to spawn clouds
        StartCoroutine(SpawnCloudRoutine());
    }
}
