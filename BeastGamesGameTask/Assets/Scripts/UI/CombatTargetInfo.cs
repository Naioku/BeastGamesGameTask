using Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class CombatTargetInfo : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private TextMeshProUGUI healthLabel;
        [SerializeField] private TextMeshProUGUI material;
        [SerializeField] private Image healthSliderFill;
        
        [Tooltip("How much the canvas have to be visible. Opposite of the opacity.")] 
        [SerializeField] [Range(0f, 1f)] private float alpha = 0.8f;

        private CanvasGroup _canvasGroup;
        
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }

        private void Start()
        {
            HideCanvas();
        }

        public void ShowInfo(float health, float maxHealth, CombatMaterial combatMaterial)
        {
            healthSlider.value = health / maxHealth;
            healthSliderFill.color = combatMaterial.Color;
            healthLabel.text = $"{health} / {maxHealth}";
            material.text = combatMaterial.name;
            material.color = combatMaterial.Color;

            ShowCanvas();
        }

        public void HideCanvas()
        {
            _canvasGroup.alpha = 0f;
        }

        private void ShowCanvas()
        {
            _canvasGroup.alpha = alpha;
        }
    }
}
