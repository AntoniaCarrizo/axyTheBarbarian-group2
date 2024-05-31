using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkSkeletonArcher : MonoBehaviour
{
    public GameObject arrowPrefab;
    public float fireRate = 1f;
    public float arrowSpawnRadius = 3f;
    private GameObject previousArrow;

    void Update()
    {
        if (Time.time > fireRate)
        {
            FireArrow();
            fireRate = Time.time + 1f; // O ajusta el fireRate a tu necesidad
        }
    }

    void FireArrow()
    {
        Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle.normalized * arrowSpawnRadius;
        GameObject newArrow = Instantiate(arrowPrefab, randomPos, Quaternion.identity);

        if (previousArrow != null)
        {
            Destroy(previousArrow);
        }

        previousArrow = newArrow;
    }
}
