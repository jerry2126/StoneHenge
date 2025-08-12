using TMPro;
using UnityEngine;

public class DisplayPower3 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;


    private void Start()
    {
        label01.text = "03";
        label02.text = "033";
    }
}