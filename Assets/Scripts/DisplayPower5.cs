using TMPro;
using UnityEngine;

public class DisplayPower5 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;


    private void Start()
    {
        label01.text = "게임 시작";
        label02.text = "Q키를 눌러 게임을 시작하세요!";
    }
}