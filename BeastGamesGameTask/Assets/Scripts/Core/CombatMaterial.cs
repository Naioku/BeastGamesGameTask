using UnityEngine;

namespace Core
{
    [CreateAssetMenu(fileName = "CombatMaterial", menuName = "Combat materials/Make new material", order = 0)]
    public class CombatMaterial : ScriptableObject
    {
        [SerializeField] private Color color = Color.HSVToRGB(105f, 68f, 93);

        public Color Color => color;
    }
}