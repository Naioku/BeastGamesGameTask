using UnityEngine;

namespace Combat
{
    public class CombatTarget : MonoBehaviour
    {
        [SerializeField] private CombatMaterial combatMaterial;
        [SerializeField] private float health = 20f;

        public CombatMaterial CombatMaterial => combatMaterial;
        
        public void TakeDamage(float damage)
        {
            health = Mathf.Max(health - damage, 0);
            RefreshDestroyedState();
        }

        private void RefreshDestroyedState()
        {
            if (health <= 0f)
            {
                DestroyCombatTarget();
            }
        }

        private void DestroyCombatTarget()
        {
            Destroy(gameObject);
        }
    }
}