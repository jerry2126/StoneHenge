using TMPro;
using UnityEngine;

public class DisplayPower5 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;


    private void Start()
    {
        label01.text = "���� ����";
        label02.text = "QŰ�� ���� ������ �����ϼ���!";
    }
}