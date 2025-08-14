using TMPro;
using UnityEngine;

public class DisplayPower2 : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label01;
    [SerializeField] TextMeshProUGUI label02;


    private void Start()
    {
        label01.text = "비석";
        label02.text = "쓰러질 경우 가까운 동물을 쫒아냅니다.";
    }
}