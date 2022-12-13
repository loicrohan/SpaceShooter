using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{ 
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _TSPUpPrefab;
    [SerializeField]
    private GameObject _SPUpPrefab;

    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(StartSpawning());  
      StartCoroutine(StartSpawningTSPU());
      StartCoroutine(StartSpawningShield());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator StartSpawning()
    {
        while (true)
        {
            Vector2 pos = new Vector2(Random.Range(-2.5f, 2.5f), transform.position.y);
            Instantiate(_enemyPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(1f);
        }
    }

    IEnumerator StartSpawningTSPU()
    {
        while (true)
        {
            Vector2 pos = new Vector2(Random.Range(-2.5f, 2.5f), transform.position.y);
            Instantiate(_TSPUpPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(25f);
        }
    }

    IEnumerator StartSpawningShield()
    {
        while (true)
        {
            Vector2 pos = new Vector2(Random.Range(-2.5f, 2.5f), transform.position.y);
            Instantiate(_SPUpPrefab, pos, Quaternion.identity);
            yield return new WaitForSeconds(35f);
        }
    }
}