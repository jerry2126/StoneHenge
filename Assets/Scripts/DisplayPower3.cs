using TMPro;
using UnityEngine;

public class DisplayPower3 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;


    private void Start()
    {
        label01.text = "����";
        label02.text = "������ �߻��������� �޷��ɴϴ�!|n��ǥ�� �����ϱ� ���� ��ġ�켼��!";
    }
}