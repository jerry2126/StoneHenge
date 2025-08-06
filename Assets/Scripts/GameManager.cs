using System;
using System.Collections.Generic;
using UnityEngine;

public enum ItemTag
{
    Aminal,
    Projectile,
    TargetStone
}
public class GameManager : MonoBehaviour
{
    [Header("Script")]
    public ProjectileSO projectileSO;
    public MainUI mainUI;
    public ProjectileLauncher projectileLauncher;
    public TargetStoneManager targetStoneManager;
    public AnimalController animalController;
    public TimeController timeController;

    [Header("Transform")]
    public Transform launchingPad;


    private void Start()
    {
        RaycastDrawer.OnRayCastHitAnimalEvent += OnRayCastHitAnimalEventHandler;
        TargetStone.OnKnockDownEvent += TargetStone_OnKnockDownEvent;
        TargetStoneManager.OnStageClearEvent += OnStageClearEvent;
        FlyingStone.OnMissionComplete += FlyingStone_OnMissionComplete;

        targetStoneManager.CreateOneTargeStone();
        animalController.Initialize();
    }

    private void FlyingStone_OnMissionComplete()
    {
        mainUI.FlyingStone_OnMissionComplete();
        timeController.TriggerSlowMotion();
    }

    private void OnStageClearEvent()
    {
       mainUI.OnStageClearEvent();   
    }

    private void TargetStone_OnKnockDownEvent(StoneType type)
    {
        animalController.RemoveCloseAnimals();
    }

    private void OnRayCastHitAnimalEventHandler()
    {
        animalController.RemoveAllAnimals();
        mainUI.OnRayCastHitAnimalEventHandler();
    }

    public void ThrowStone()
    {
        projectileLauncher.ThrowStone();
        animalController.RunToPlayer();
    }
}