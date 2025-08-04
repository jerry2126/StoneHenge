using TMPro;
using UnityEngine;

public class TestWorldSpaceNameTag : MonoBehaviour
{
    [SerializeField] GameObject nameTagPrefab;
    [SerializeField] Transform target;
    TextMeshProUGUI label01;
    TextMeshProUGUI label02;


    private void Start()
    {
        GameObject clone = Instantiate(nameTagPrefab);

        clone.transform.SetParent(transform);

        clone.transform.localPosition = Vector3.zero;

        TextMeshProUGUI[] text = clone.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (var tmp in text)
        {
            if (tmp.name=="label01")
            {

            }
        }
    }
}
