using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrunkSkeletonArcher : MonoBehaviour
{
    public GameObject arrowPrefab; // Prefab de la flecha que se disparará
    public float fireRate = 1f; // Frecuencia de disparo en segundos
    private float nextFireTime; // Tiempo en el que se disparará la siguiente flecha
    public float arrowSpawnRadius = 3f; // Radio en el que aparecerá la flecha
    private GameObject previousArrow; // Referencia a la flecha previa disparada

    void Start()
    {
        // No es necesario agregar nada aquí
    }

    void FireArrow()
    {
        // Calcula una posición aleatoria dentro del radio arrowSpawnRadius (en 2D)
        Vector2 randomPos = (Vector2)transform.position + Random.insideUnitCircle.normalized * arrowSpawnRadius;

        // Instancia un nuevo objeto flecha
        GameObject newArrow = Instantiate(arrowPrefab, randomPos, Quaternion.identity);

        // Si había una flecha previa, destrúyela
        if (previousArrow != null)
        {
            Destroy(previousArrow);
        }

        // Guarda la referencia a la nueva flecha
        previousArrow = newArrow;
    }

    void Update()
    {
        if (Time.time > nextFireTime)
        {
            FireArrow();
            nextFireTime = Time.time + fireRate;
        }
    }
}