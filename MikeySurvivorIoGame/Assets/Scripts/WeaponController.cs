using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QFSW.QC;

public class WeaponController : MonoBehaviour
{
    public List<GameObject> detectedWeapons = new List<GameObject>();

    private void Start()
    {
        if (transform.childCount == 0) { Debug.LogError("No weapons have been detected! Check if all weapons are tagged with 'Weapon' and there are weapon objects present"); return; }

        foreach (Transform t in transform)
        {
            if (t.CompareTag("Weapon"))
            {
                detectedWeapons.Add(t.gameObject);
                t.gameObject.SetActive(false);
            }
        }
    }

    [Command("activate-weapon")]
    public void ActivateWeapon(string weaponId)
    {
        foreach (GameObject g in detectedWeapons)
        {
            g.SetActive(false);
            if (g.GetComponent<Weapon>().weaponData.weaponId == weaponId)
            {
                g.SetActive(true);
                return;
            }
        }
    }
}
