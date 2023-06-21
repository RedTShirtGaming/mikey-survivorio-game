using UnityEngine;
using UnityEngine.UI;

public enum AttackType { Ranged, Melee, Other}
public enum RangedAttackType { Single, Shotgun }

[CreateAssetMenu]
public class WeaponScriptableObject : ScriptableObject
{
    [Space(10), Header("Stats")]

    public new string name;
    [SerializeField] string _weaponId;
    public string weaponId { get { return _weaponId; } set { _weaponId = value; } }
    [TextArea] public string description;
    [Tooltip("Type of attack. AttackType.Other shouldn't be used if possible.")] public AttackType attackType;
    public RangedAttackType rangedAttackType;
    [Tooltip("Weapon damage.")] public float damage;
    [Tooltip("Weapon critical damage.")] public float criticalDamage;
    [Tooltip("Critical percent chance."), Range(0, 100)] public int criticalChance;

    [Space(10), Header("Misc")]

    public Image weaponImage;

    bool isInitialised;
    bool Initialise()
    {
        

        // returns true so that isInitialised becomes true after this function runs
        return true;
    }

    private void OnValidate()
    {
        if (!isInitialised) isInitialised = Initialise();
        weaponId = name.ToLower().Replace(" ", "-");
    }

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
