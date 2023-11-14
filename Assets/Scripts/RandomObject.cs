using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomObject : MonoBehaviour
{
    public GameObject targetPrefab1;
    public GameObject targetPrefab2;
    public GameObject targetPrefab3;

    float startSec = 15;
    float destroySec = 15;

    void Awake()
    {
        StartCoroutine(TimerStartObject(startSec));
    }

    private IEnumerator TimerStartObject(float sec)
    {
        yield return new WaitForSeconds(sec);
        Spawner();
    }

    void Spawner()
    {
        Vector3 randomSpawnPosition1 = new Vector3(Random.Range(-19, 20), Random.Range(1, 3), Random.Range(1, 15));
        Vector3 randomSpawnPosition2 = new Vector3(Random.Range(-19, 20), Random.Range(1, 3), Random.Range(1, 15));
        Vector3 randomSpawnPosition3 = new Vector3(Random.Range(-19, 20), Random.Range(1, 3), Random.Range(1, 15));

        GameObject go1 = Instantiate(targetPrefab1, randomSpawnPosition1, Quaternion.identity);
        GameObject go2 = Instantiate(targetPrefab2, randomSpawnPosition2, Quaternion.identity);
        GameObject go3 = Instantiate(targetPrefab3, randomSpawnPosition3, Quaternion.identity);

        Destroy(go1, destroySec);
        Destroy(go2, destroySec);
        Destroy(go3, destroySec);

        StartCoroutine(TimerStartObject(startSec));
    }
}
