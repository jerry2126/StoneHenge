using TMPro;
using UnityEngine;

public class DisplayPower : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;

    private void Start()
    {
        label01.text = "ª°∞£ µπ∏Õ¿Ã";
        label02.text = "»˚: 100";
    }
}