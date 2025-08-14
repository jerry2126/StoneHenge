using Unity.Burst.CompilerServices;
using UnityEngine;

public class IntroCameraWork : MonoBehaviour
{
    public void PlayAnimationByName(GameObject targetObject)
    {
        Animator animator = targetObject.GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogWarning("Animator component not found on the target object: " + targetObject.name);
            return;
        }
        animator.SetTrigger("PlayAnimation");
        Debug.Log("PlayAnimationBy:" + targetObject.name);
    }
}