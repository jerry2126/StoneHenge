using Controller;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public CreatureMover creatureMover;
    [SerializeField] GameObject player;
    [SerializeField] float mySpeed;


    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (creatureMover.IsRun == false)
        {
            mySpeed = creatureMover.m_WalkSpeed;
        }
        else
        {
            mySpeed = creatureMover.m_RunSpeed;
        }

        if (player != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, mySpeed * Time.deltaTime);
        }
    }
}