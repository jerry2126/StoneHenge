using System.Collections;
using TMPro;
using UnityEngine;

public class WorldSpaceNameTag : MonoBehaviour
{
    [SerializeField] GameObject[] allObjects;
    [SerializeField] GameObject nameTagPrefab;
    [SerializeField] Transform target;

    TextMeshProUGUI label01;
    TextMeshProUGUI label02;

    public Transform CameraTarget;
    public float smoothing = 5f;
    public Vector3 offset;

    private string label01Text;
    private string label02Text;


    public void CreateDisplay(Transform target)
    {
        //return; // This method is not used in the current context, so we can skip it.
        GameObject clone = Instantiate(nameTagPrefab);
        clone.transform.SetParent(target);
        clone.transform.localPosition = new Vector3(0, 3, 0);
        TextMeshProUGUI[] texts = clone.GetComponentsInChildren<TextMeshProUGUI>();

        foreach (var tmp in texts)
        {
            if (tmp.name == "label01")
            {
                tmp.text = label01Text;
                label01 = tmp;

            }
            else if (tmp.name == "label02")
            {
                tmp.text = label02Text;
                label02 = tmp;
            }
        }
        //label01.text = label01Text;
        //label02.text = label02Text;
    }

    public void DisplayTextType(string TextType)
    {
        if (TextType == "Cube01")
        {
            label01Text = "Cube 01";
            label02Text = "Cube 01";
        }

        if (TextType == "Cube02")
        {
            label01Text = "Cube 02";
            label02Text = "Cube 02";
        }

        if (TextType == "Cube03")
        {
            label01Text = "Cube 03";
            label02Text = "Cube 03";
        }

        if (TextType == "Cube04")
        {
            label01Text = "Cube 04";
            label02Text = "Cube 04";
        }

        if (TextType == "Cube05")
        {
            label01Text = "Cube 05";
            label02Text = "Cube 05";
        }
    }

    void CreateUI()
    {
        GameObject clone = Instantiate(nameTagPrefab);
        clone.transform.SetParent(target);
        clone.transform.localPosition = Vector3.zero;
        TextMeshProUGUI[] texts = clone.GetComponentsInChildren<TextMeshProUGUI>();
        Debug.Log(texts.Length);

        foreach (var tmp in texts)
        {
            if (tmp.name == "label01")
            {
                tmp.text = "fffffffffff";
                label01 = tmp;
            }
            else if (tmp.name == "label02")
            {
                tmp.text = "???????????";
                label02 = tmp;
            }
        }
        label01.text = "finally";
        label02.text = "I found it";
    }

    IEnumerator StartDisplayCor()
    {
        yield return null;
    }
}