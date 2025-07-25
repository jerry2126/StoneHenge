using Controller;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] MovePlayerInput _movePlayerInput;
    [SerializeField] CreatureMover _creatureMover;

    public float MyWalkSpeed;
    public float MyRunSpeed;

    private void Start()
    {
        
    }

    private void Update()
    {
        Vector2 vec2 = new Vector2(1, 1);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            _movePlayerInput.GatherInputSample(vec2, true);
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _movePlayerInput.GatherInputSample(vec2, false);
        }

        _creatureMover.SetMoveSpeed(MyWalkSpeed, MyRunSpeed);
    }
}