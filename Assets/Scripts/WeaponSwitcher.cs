using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int currentWeapon = 0;
    Weapon[] weapons;


    private void Start()
    {
        weapons = GetComponentsInChildren<Weapon>();

        int weaponIndex = 0;
        foreach(Weapon weapon in weapons)
        {
            if (currentWeapon != weaponIndex)
                weapon.gameObject.SetActive(false);
            weaponIndex++;
        }

    }
    // Update is called once per frame
    void Update()
    {
        HandleNumberPressed();
        HandleScrollWheel();

    }

    private void HandleScrollWheel()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (currentWeapon == weapons.Length - 1)
                ChangeWeapon(0);
            else
                ChangeWeapon(currentWeapon + 1);
        }
        
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (currentWeapon == 0)
                ChangeWeapon(weapons.Length - 1);
            else
                ChangeWeapon(currentWeapon - 1);
        }
    }

    private void HandleNumberPressed()
    {
        int weaponChosen;

        if (Input.inputString != "" && int.TryParse(Input.inputString, out weaponChosen))
        {
            weaponChosen--;

            if (weaponChosen >= 0 && weaponChosen < weapons.Length)
            {
                ChangeWeapon(weaponChosen);
            }
        }
    }

    private void ChangeWeapon(int weaponChosen)
    {
        weapons[currentWeapon].gameObject.SetActive(false);
        currentWeapon = weaponChosen;
        weapons[currentWeapon].gameObject.SetActive(true);
    }
}
