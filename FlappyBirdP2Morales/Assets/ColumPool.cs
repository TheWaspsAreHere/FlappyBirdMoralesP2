using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumPool : MonoBehaviour
{
    public int columPoolSize = 5;
    public GameObject columPrefab;
    public float spawnRate = 4f;
    public float columMin = -1f;
    public float columMax = 3.5f;

    private GameObject[] colums;
    private Vector2 objectPoolPosition = new Vector2(-15f, -25);
    private float timeSinceLastSpawned;
    private float spawnXPosition = 10f;
    private int currentColum = 0;

    // Start is called before the first frame update
    void Start()
    {
        colums = new GameObject[columPoolSize];
        for (int i = 0; i < columPoolSize; i++)
        {
            colums[i] = (GameObject) Instantiate(columPrefab, objectPoolPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastSpawned += Time.deltaTime;

        if (GameControl.instance.gameOver == false && timeSinceLastSpawned >= spawnRate)
        {
            timeSinceLastSpawned = 0;
            float spawnYPosition = Random.Range (columMin, columMax);
            colums[currentColum].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
            currentColum++;
            if (currentColum >= columPoolSize)
            {
                currentColum = 0;
            }
        }
    }
}
