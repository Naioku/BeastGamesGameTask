using Core;
using TMPro;
using UnityEngine;

namespace UI
{
    public class WeaponInfo : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI materialLabel;
        [SerializeField] private TextMeshProUGUI damageLabel;
        private void Update()
        {
            if (Input.GetButton("WeaponCheck"))
            {
                ShowCanvas();
            }
            else
            {
                HideCanvas();
            }
        }
        
        public void UploadInfo(float damage, CombatMaterial combatMaterial)
        {
            damageLabel.text = damage.ToString();
            materialLabel.text = combatMaterial.name;
            materialLabel.color = combatMaterial.Color;
        }
        
        private void HideCanvas()
        {
            GetComponent<ShowHideCanvas>().HideCanvas();
        }
        
        private void ShowCanvas()
        {
            GetComponent<ShowHideCanvas>().ShowCanvas();
        }
    }
}
