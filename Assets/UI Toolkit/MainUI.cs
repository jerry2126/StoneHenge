using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class MainUI : MonoBehaviour
{
    [Header("Script")]
    [SerializeField] GameManager gameManager;

    [Header("UI"), Space(10)]
    [SerializeField] UIDocument _document;
    [SerializeField] StyleSheet _styleSheet;

    [Header("Transform")]
    [SerializeField] Transform cannon;      //Y angle
    [SerializeField] Transform gunBarrel;   //X angle

    [Header("Images")]
    public Sprite ProjectileSprite;
    public Sprite targetStoneSprite;
   
    VisualElement root;
    VisualElement container;
    Button throwBtn, drawBtn, quitBtn;
    Slider BarrelSlider, CannonSlider, speedSlider, massSlider;


    public void OnValidate()
    {
        if (Application.isPlaying) return;
       // GenerateUI();
    }

    private void GenerateUI()
    {
        root = _document.rootVisualElement;       
        root.styleSheets.Add(_styleSheet);
             
        root.Clear();

        container = UTIL.Create<VisualElement>("container");
        drawBtn = UTIL.Create<Button>("button");
        throwBtn = UTIL.Create<Button>("button");
        quitBtn = UTIL.Create<Button>("button");
        throwBtn.text = "Throw";
        drawBtn.text = "Draw";
        quitBtn.text = "Quit";

        BarrelSlider = UTIL.Create<Slider>("my-slider");
        BarrelSlider.label = $"Y angle";
        CannonSlider = UTIL.Create<Slider>("my-slider");
        CannonSlider.label = $"Z angle";
        massSlider = UTIL.Create<Slider>("my-slider");
        massSlider.label = $"Mass";
        speedSlider = UTIL.Create<Slider>("my-slider");
        speedSlider.label = $"Speed";
        VisualElement buttonContainer = UTIL.Create<VisualElement>("head-box");

        buttonContainer.Add(throwBtn);
        buttonContainer.Add(drawBtn);
        buttonContainer.Add(quitBtn);

        container.Add(buttonContainer);

        container.Add(BarrelSlider);
        container.Add(CannonSlider);
        container.Add(massSlider);
        container.Add(speedSlider);
        root.Add(container);
    }

    private void Awake()
    {
        root = _document.rootVisualElement;
        root.styleSheets.Add(_styleSheet);
    }

    private void Start()
    {
        GenerateUI();
        Initialize();
        AddListener();
    }

    public void OnStageClearEvent()
    {
        List<string> list = new List<string>();
        list.Add("WOW");
        list.Add("You Won");
        ShowPopup(list, WhenYouWin);
    }

    public void OnRayCastHitAnimalEventHandler() 
    {
        List<string> list = new List<string>();
        list.Add("Lose");
        list.Add("You lost");
        ShowPopup(list, WhenYouLose);
    }

    void WhenYouLose()
    {        
        Debug.Log("Game again!");
    }

    void WhenYouWin()
    {
        gameManager.targetStoneManager.CreateOneTargeStone();
    }

    private void SeupElements()
    {
        CannonSlider.lowValue = 180f-30f;
        CannonSlider.highValue = 180f+30f;

        BarrelSlider.lowValue = 12.5f-20f;
        BarrelSlider.highValue = 12.5f+20f;

        CannonSlider.value = 180f;
        BarrelSlider.value = 12.5f;

        massSlider.lowValue = 1f;
        massSlider.highValue = 5f;

        speedSlider.lowValue = 10f;
        speedSlider.highValue = 30f;
    }

    private void Initialize()
    {
        SeupElements();
       
        speedSlider.value = gameManager.projectileSO.speed;
        massSlider.value = gameManager.projectileSO.mass;

        //image
        // Create the image element
        Image image = new Image();
        image.sprite = ProjectileSprite; // Assign your sprite here
        image.scaleMode = ScaleMode.ScaleToFit;
        image.style.flexGrow = 1;

        throwBtn.Add(image);
    }

    void AddListener()
    {
        throwBtn.clicked += OnThrowButtonClick;
        drawBtn.clicked += OnDrawButtonClick;
        quitBtn.clicked += OnQuitButtonClick;

        drawBtn.RegisterCallback<MouseEnterEvent>(evt =>
        {
            drawBtn.style.backgroundColor = new StyleColor(Color.green);
            gameManager.projectileLauncher.isDrawing = true;
        });

        drawBtn.RegisterCallback<MouseLeaveEvent>(evt =>
        {
            drawBtn.style.backgroundColor = new StyleColor(Color.white);
            //myProjectileLauncher.isDrawing = false;
        });

        CannonSlider.RegisterValueChangedCallback(evt =>
        {
            cannon.localRotation = Quaternion.Euler(0f, evt.newValue, 0f);
        });

        BarrelSlider.RegisterValueChangedCallback(evt =>
        {
            gunBarrel.localRotation = Quaternion.Euler(0f, evt.newValue, 0f);
        });


        speedSlider.RegisterValueChangedCallback(evt =>
        {
            gameManager.projectileSO.speed = evt.newValue;
            speedSlider.label = string.Concat(evt.newValue.ToString(), " Speed");
        });

        massSlider.RegisterValueChangedCallback(evt =>
        {
            gameManager.projectileSO.mass = evt.newValue;
            massSlider.label = string.Concat(evt.newValue.ToString(), " Mass");
        });
    }

    private void OnQuitButtonClick()
    {

    }

    private void OnDrawButtonClick()
    {

    }

    private void OnThrowButtonClick()
    {
        gameManager.ThrowStone();
        container.visible = false;
    }

    public void FlyingStone_OnMissionComplete()
    {
        //TODO 시점 조정 
        container.visible = true;
    }
   
    public void ShowPopup(List<string> texts, Action myAction)
    {
        var _popupContainer = UTIL.Create<VisualElement>("full-box");
        var _popup = UTIL.Create<VisualElement>("popup-container");

        foreach (string text in texts)
        {
            Label label = UTIL.Create<Label>("label");
            label.AddToClassList("label-exercise");
            label.text = text;
            _popup.Add(label);
        }
        var closebtn = UTIL.Create<Button>("button", "bottom-button");
        closebtn.text = "Close";
        closebtn.clicked += () =>
        {
            myAction.Invoke();
            StartCoroutine(FadeOut(_popupContainer));
        };

        _popupContainer.Add(_popup);
        _popupContainer.Add(closebtn);
        root.Add(_popupContainer);
        StartCoroutine(FadeIn(_popupContainer));
    }

    IEnumerator FadeIn(VisualElement element)
    {
        element.AddToClassList("fade");
        yield return null;
        element.AddToClassList("fade-in");
    }

    IEnumerator FadeOut(VisualElement element)
    {
        element.AddToClassList("fade-hidden");
        yield return new WaitForSeconds(0.5f);
        element.RemoveFromHierarchy();
    }
}