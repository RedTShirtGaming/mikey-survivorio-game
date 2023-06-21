using UnityEngine;
using UnityEngine.UI;

public enum AttackType { Ranged, Melee, Other}
public enum RangedAttackType { Single, Shotgun }

[CreateAssetMenu]
public class WeaponScriptableObject : ScriptableObject
{
    [Space(10), Header("Stats")]

    public new string name;
    [TextArea] public string description;
    [Tooltip("Type of attack. AttackType.Other shouldn't be used if possible.")] public AttackType attackType;
    public RangedAttackType rangedAttackType;
    [Tooltip("Weapon damage.")] public float damage;
    [Tooltip("Weapon critical damage.")] public float criticalDamage;
    [Tooltip("Critical percent chance."), Range(0, 100)] public int criticalChance;

    [Space(10), Header("Misc")]

    public Image weaponImage;

    public bool GenerateRandomCritical()
    {
        if (criticalChance >= 100) return true; else if (criticalChance <= 0) return false;
        else
        {
            float randomValue = Random.Range(0f, 1f);
            float normalizedPercentage = criticalChance / 100f;
            return randomValue < normalizedPercentage;
        }
    }
}
