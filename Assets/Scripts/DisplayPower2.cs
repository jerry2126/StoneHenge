using TMPro;
using UnityEngine;

public class DisplayPower2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;


    private void Start()
    {
        label01.text = "02";
        label02.text = "022";
    }
}