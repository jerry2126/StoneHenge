using System;
using System.Collections;
using UnityEngine;

public class AnimalSpawner : MonoBehaviour
{
    public static event Action OnSpawnAnimalEvent;

    [SerializeField] Transform container;
    public Transform spawnPoint;
    public GameObject animalPrefab;

    public int animalCount;
    public float spacing = 2f; // Distance between cubes
    public float radius = 2f;

    public LayerMask targetLayer;
    [SerializeField] ItemTag animalTag;
    [SerializeField] ItemTag targetTag;

    GameObject[,] objectGrid;
    int count = 0;
    void FindAndRemove(Vector3 pos, float myRadius)
    {
        Vector3 point = pos;
        float radius = myRadius;

        Collider[] hits = Physics.OverlapSphere(point, radius * 5, targetLayer);

        foreach (Collider col in hits)
        {
            GameObject obj = col.gameObject;
            Destroy(obj);
        }
        StartCoroutine(CheckLastAnimal());
    }

    IEnumerator CheckLastAnimal()
    {
        yield return null;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(animalTag.ToString());

        if (enemies.Length == 0)
        {
            yield return new WaitForSeconds(1);
            OnSpawnAnimalEvent?.Invoke();
            SpawnAnimal();
        }
    }


    private void Start()
    {
        TargetStone.OnKnockDownToAnimalEvent += TargetStone_OnKnockDownEvent;
        //TargetStone.OnHitByProjectile += TargetStone_OnHitByProjectile;

        SpawnAnimal();
    }

    private void TargetStone_OnHitByProjectile(StoneType obj)
    {
        DestoryFrontLine(count);
        count++;
    }

    private void TargetStone_OnKnockDownEvent(Vector3 pos)
    {
        FindAndRemove(pos, radius);
    }

    public void SpawnAnimal()
    {
        objectGrid = new GameObject[animalCount, animalCount];
        count = 0;
        int gridSize = Mathf.CeilToInt(Mathf.Pow(animalCount, 1f / 3f)); // Cube root for 3D grid
        int y = 1;

        for (int x = 0; x < animalCount; x++)
        {
            for (int z = 0; z < animalCount; z++)
            {
                Vector3 position = new Vector3(x, y, z) * spacing;
                GameObject clone = Instantiate(animalPrefab, position, Quaternion.identity);
                clone.transform.SetParent(container, false);
                objectGrid[x, z] = clone;
            }
        }
    }

    void DestoryFrontLine(int index)
    {
        for (int col = 0; col < animalCount; col++)
        {
            GameObject obj = objectGrid[index, col];
            if (obj != null)
            {
                Destroy(obj);
            }
        }
        CheckLastAnimal();
    }
}