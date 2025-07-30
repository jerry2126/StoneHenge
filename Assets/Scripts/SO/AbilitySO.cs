using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "AbilitySO", menuName = "Scriptable Objects/AbilitySO")]
public class AbilitySO : ScriptableObject
{
    public string label;

    public GameObject vfxPrefab;

    [SerializeReference] public List<AbilityEffect> effects;

    void OnEnable()
    {
        if (string.IsNullOrEmpty(label)) label = name;
        if (effects == null) effects = new List<AbilityEffect>();
    }
}

[Serializable]
public abstract class AbilityEffect // Changed to public to match accessibility  
{
    public abstract void Execute(GameObject caster, GameObject target);
}

[Serializable]
public class DamageEffect : AbilityEffect // Changed to public to match accessibility  
{
    public int amount;

    public override void Execute(GameObject caster, GameObject target)
    {
        target.GetComponent<Health>().ApplyDamage(amount);
        Debug.Log($"{caster.name} dealt {amount} damage to {target.name}");
    }
}

[Serializable]
public class KnockbackEffect : AbilityEffect // Changed to public to match accessibility  
{
    public float force;

    public override void Execute(GameObject caster, GameObject target)
    {
        var dir = (target.transform.position - caster.transform.position).normalized;
        target.GetComponent<Rigidbody>().AddForce(dir * force, ForceMode.Impulse);
        Debug.Log($"{caster.name} knocked back {target.name} with force {force}");
    }
}
