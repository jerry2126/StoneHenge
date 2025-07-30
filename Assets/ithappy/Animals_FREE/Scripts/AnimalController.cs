using Controller;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] List<GameObject> animals;
    [SerializeField] Transform container;  //parent...
    [SerializeField] EffectOnAnimal effectOnAnimal;
    public GameObject player;  //
    public float spacing = 2f; // Dist

    int animalCount = 5;

    Vector2 vec2 = new Vector2(-5, -5);  // run, walk   건네주기 위한 

    private void Awake()
    {
        SpawnAnimals();
        EnableAnimals();
    }

    public void RunToPlayer()
    {
        foreach (Transform child in container)
        {
            Vector2 vec2 = new Vector2(0, 1);
            child.GetComponent<MovePlayerInput>().GatherInputSample(vec2, true, player.transform.position);
        }
    }

    void CollectAnimals()
    {
        List<Transform> allObjects = new List<Transform>();

        foreach (Transform child in container)
        {
            allObjects.Add(child);
        }

        List<Transform> closestObjects = allObjects
            .OrderBy(obj => Vector3.Distance(player.transform.position, obj.position))
            .Take(5)
            .ToList();

        foreach (Transform obj in closestObjects)
        {
            Debug.Log("Close object: " + obj.name);
            effectOnAnimal.Disappear(obj.transform.position);
            Destroy(obj.gameObject);
        }
    }

    public void GetMoveAnimal()
    {
        foreach (Transform child in container)
        {
            child.GetComponent<MovePlayerInput>().GatherInputSample(vec2, true);
        }
    }

    public void SpawnAnimals()
    {
        int gridSize = Mathf.CeilToInt(Mathf.Pow(animalCount, 1f / 3f)); // Cube root for 3D grid
        int y = 1;

        for (int x = 0; x < animalCount; x++)
        {
            for (int z = 0; z < animalCount; z++)
            {
                Vector3 position = new Vector3(x, y, z) * spacing;
                GameObject clone = Instantiate(animals[Random.Range(0, animals.Count)], position, Quaternion.identity);
                clone.transform.SetParent(container, false);
                //TODO...
                clone.GetComponent<MovePlayerInput>().enabled = false;
                clone.GetComponent<CreatureMover>().enabled = false;
            }
        }
    }

    public void EnableAnimals()
    {
        foreach (Transform child in container)
        {
            child.GetComponent<MovePlayerInput>().enabled = true;
            child.GetComponent<CreatureMover>().enabled = true;
        }
    }

    public void FindAndUpdate()
    {
        Vector2 vec2 = new Vector2(-5, -5);
        foreach (Transform child in container)
        {
            child.GetComponent<CreatureMover>().SetMovement(vec2);
        }
    }

    
}