using UnityEngine;

public class IntroCameraWork : MonoBehaviour
{
    [SerializeField] GameObject Luancher;
    [SerializeField] GameObject TargetStone;
    [SerializeField] GameObject Animal;
    [SerializeField] GameObject EndPoint;
    [SerializeField] GameObject StartGame;


    public void PlayAnimationByName(Transform targetObject)
    {
        if (targetObject==null)
        {
            Debug.Log("Target object is null. Cannot play animation.");
            return;
        }

        Animator animator = targetObject.GetComponent<Animator>();

        if (targetObject == Luancher.transform)
        {
            animator.Play("LuancherRotation");
        }

        if (targetObject == TargetStone.transform)
        {
            animator.Play("RockUpAndDown");
        }

        if (targetObject == Animal.transform)
        {

        }

        if (targetObject == EndPoint.transform)
        {

        }

        if (targetObject == StartGame.transform)
        {

        }
        Debug.Log("PlayAnimationBy" + targetObject);
    }
}