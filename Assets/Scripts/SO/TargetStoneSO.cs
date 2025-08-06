using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "TargetStoneSO", menuName = "Scriptable Objects/TargetStoneSO")]
public class TargetStoneSO : ScriptableObject
{
    public float width, hight;
    public float mass;
    public Vector3 scale;
    public int level;
}