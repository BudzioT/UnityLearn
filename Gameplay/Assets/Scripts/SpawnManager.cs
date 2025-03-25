using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;
    public float spawnRangeX = 18f;
    public float spawnPointLeft = -30f;
    public float spawnPointRight = 18f;
    private const float SpawnZ = 18f;

    private const float SpawnZTop = 18f;
    private const float SpawnZBottom = -3f;

    public float spawnDelay = 2;
    public float spawnInterval = 1.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating(nameof(SpawnAnimal), spawnDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnAnimal()
    {
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        bool setRotation = false;
        
        float vertOrHorz = Random.Range(0f, 1f);
        Vector3 spawnPos;
        if (vertOrHorz > 0.35f)
        {
            spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, SpawnZ);
        }
        else
        {
            int leftOrRight = Random.Range(0, 2);
            float posX = (leftOrRight == 0 ? spawnPointLeft : spawnPointRight);
            setRotation = true;
            rotation = Quaternion.Euler(0, leftOrRight == 0 ? 90 : 270, 0);
            spawnPos = new Vector3(posX, 0, Random.Range(SpawnZBottom, SpawnZTop));
        }
           
        int animalIndex = Random.Range(0, animals.Length);
        if (!setRotation)
        {
            rotation = animals[animalIndex].transform.rotation;
        }
        
        Instantiate(animals[animalIndex], spawnPos, rotation);
    }
}
