using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    private readonly float _minInterval = 5f;
    private readonly float _maxInterval = 10f;
    public Vector3 minPosition;
    public Vector3 maxPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke(nameof(spawnPrefab), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawnPrefab()
    {
        Vector3 randPos = new Vector3(
            Random.Range(minPosition.x, maxPosition.x),
            Random.Range(minPosition.y, maxPosition.y),
            Random.Range(minPosition.z, maxPosition.z)
        );

        int randomPrefabIndex = Random.Range(0, prefabs.Length);

        Instantiate(prefabs[randomPrefabIndex], randPos, prefabs[randomPrefabIndex].transform.rotation);
        
        Invoke(nameof(spawnPrefab), Random.Range(_minInterval, _maxInterval));
    }
}
