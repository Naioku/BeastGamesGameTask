using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(ShowHideCanvas))]
    public class CombatTargetInfo : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TextMeshProUGUI healthLabel;
        [SerializeField] private TextMeshProUGUI material;
        [SerializeField] private Image healthSliderFill;

        public void UploadInfo(float health, float maxHealth, CombatMaterial combatMaterial)
        {
            healthSlider.value = health / maxHealth;
            healthSliderFill.color = combatMaterial.Color;
            healthLabel.text = $"{health} / {maxHealth}";
            material.text = combatMaterial.name;
            material.color = combatMaterial.Color;
        }

        public void HideCanvas()
        {
            GetComponent<ShowHideCanvas>().HideCanvas();
        }
        
        public void ShowCanvas()
        {
            GetComponent<ShowHideCanvas>().ShowCanvas();
        }
    }
}
