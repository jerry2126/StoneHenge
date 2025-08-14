using TMPro;
using UnityEngine;

public class DisplayPower3 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;


    private void Start()
    {
        label01.text = "동물";
        label02.text = "위험한 야생동물들이 달려옵니다!|n목표에 도달하기 전에 해치우세요!";
    }
}