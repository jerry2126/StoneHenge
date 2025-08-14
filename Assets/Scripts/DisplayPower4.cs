using TMPro;
using UnityEngine;

public class DisplayPower4 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;


    private void Start()
    {
        label01.text = "목표";
        label02.text = "이곳에 동물이 들어오변 게임오버됩니다.|n두 번 까지 버틸 수 있습니다.";
    }
}