using System;
using UnityEngine;

public class TargetStoneManager : MonoBehaviour
{
    public static event Action OnStageClearEvent;
    [SerializeField] GameObject stonePrefab;
    [SerializeField] QuadCreator quadCreator;
    [SerializeField] RaycastAtHeight raycastAtHeight;
    [SerializeField] int count = default(int);
    [SerializeField] TargetStoneSO[] targetStoneSO;

    Vector3 scale = new Vector3(1f, 1f, 1f);
    Vector3 pos;
    public float newMass = 1;
    public int clearCount = 3;


    private void Start()
    {
        quadCreator.CreateQuad();
        TargetStone.OnKnockDownEvent += TargetStone_OnKnockDownEvent;
        raycastAtHeight.OnStoneHasFallenEvent += RaycastAtHeight_OnStoneHasFallenEvent;   
    }

    private void RaycastAtHeight_OnStoneHasFallenEvent()
    {
        TargetStone_OnKnockDownEvent(StoneType.High);
    }

    private void TargetStone_OnKnockDownEvent(StoneType obj)
    {
        count++;
        if (count == clearCount)
        {
            count = 0;
            ResetValue();
            OnStageClearEvent?.Invoke();
            return;
        }

        GameObject[] objects = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject item in objects)
        {
            Destroy(item);
        }
        //quadCreator.CreateQuad();
        CreateOneTargeStone();
    }




    /// <summary>
    /// /////////////////////////////////////////////////
    /// </summary>


    public void CreateOneTargeStone()//여기서 so의 lv에 따라 쿼드크기, 돌맹이 사이즈, 돌맹이 질량 설정하기
    {
        quadCreator.CreateQuad();
        //range 
        pos = quadCreator.GetArea();
        pos.y = 0.1f;

        //size
        stonePrefab.transform.localScale = scale;

        //mass
        Rigidbody rb = stonePrefab.GetComponent<Rigidbody>();
        if (rb != null) rb.mass = newMass;

        var clone =  Instantiate(stonePrefab, pos, Quaternion.identity);
        raycastAtHeight.Init(clone);
    }

    public void ResetValue()
    {
        //size
        scale = new Vector3(scale.x += 0.1f, scale.y += 0.3f, scale.z += 0.3f);

        //mass
        newMass += 1;

        quadCreator.CreateQuad();
    }
}