using TMPro;
using UnityEngine;

public class DisplayPower : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;


    public void SetPower(string name, string text)
    {
        label01.text = name;
        label02.text = text;
    }
}