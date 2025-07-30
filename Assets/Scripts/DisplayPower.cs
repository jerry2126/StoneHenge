using TMPro;
using UnityEngine;

public class DisplayPower : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;

    private void Start()
    {
        label01.text = "Red Stone";
        label02.text = "Power: 100";
    }
}