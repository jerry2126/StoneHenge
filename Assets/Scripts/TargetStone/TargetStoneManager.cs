using System;
using UnityEngine;
using static UnityEngine.Rendering.HighDefinition.ScalableSettingLevelParameter;

public class TargetStoneManager : MonoBehaviour
{
    public static event Action OnStageClearEvent;
    public GameObject stonePrefab;
    [SerializeField] QuadCreator quadCreator;

    [SerializeField] TargetStoneSO[] targetStoneSO;

    Vector3 pos;
    public int level = default(int);
    public int count = default(int);
    public int clearCount = 3;


    private void Start()
    {
        TargetStone.OnKnockDownEvent += TargetStone_OnKnockDownEvent;
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
            level++;
            count = 0;
            OnStageClearEvent?.Invoke();
            return;
        }
        CreateOneTargeStone();
    }

    public void CreateOneTargeStone()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Target");
        foreach (GameObject item in objects)
        {
            Destroy(item);
        }

        //quad.width & quad.hight
        quadCreator.Setup(targetStoneSO[level].width, targetStoneSO[level].hight);

        //quad create
        quadCreator.CreateQuad();

        //quad.Stone random range   //stone pos
        pos = quadCreator.GetRandomPoint();
        pos.y = 0.5f;

        //stone.scale
        stonePrefab.transform.localScale = targetStoneSO[level].scale;

        //stone.mass
        Rigidbody rb = stonePrefab.GetComponent<Rigidbody>();
        if (rb != null) rb.mass = targetStoneSO[level].mass;

        var clone =  Instantiate(stonePrefab, pos, Quaternion.identity);
    }
}