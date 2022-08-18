using UnityEngine;

namespace Control
{
    public class SwitchWeapon : MonoBehaviour
    {
        [SerializeField] private GameObject[] weapons;
        
        private int _activeWeaponIndex;

        private void Start()
        {
            DisableAllWeapons();
            EnableWeaponAt(0);
        }

        void Update()
        {
            if (Input.GetButtonDown("TakeWeapon1"))
            {
                DisableActiveWeapon();
                EnableWeaponAt(0);
            }
            if (Input.GetButtonDown("TakeWeapon2"))
            {
                DisableActiveWeapon();
                EnableWeaponAt(1);
            }
            if (Input.GetButtonDown("TakeWeapon3"))
            {
                DisableActiveWeapon();
                EnableWeaponAt(2);
            }
        }

        private void DisableAllWeapons()
        {
            foreach (var weapon in weapons)
            {
                weapon.SetActive(false);
            }
        }

        private void EnableWeaponAt(int index)
        {
            weapons[index].SetActive(true);
            _activeWeaponIndex = index;
        }

        private void DisableActiveWeapon()
        {
            weapons[_activeWeaponIndex].SetActive(false);
        }
    }
}
