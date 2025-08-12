using TMPro;
using UnityEngine;

public class DisplayPower4 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;


    private void Start()
    {
        label01.text = "04";
        label02.text = "044";
    }
}