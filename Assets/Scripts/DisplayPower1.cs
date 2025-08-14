using TMPro;
using UnityEngine;

public class DisplayPower1 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;


    private void Start()
    {
        label01.text = "대포";
        label02.text = "돌맹이를 발사하여 비석을 맞춥니다.";
    }
}