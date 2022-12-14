using Core;
using UnityEngine;
using UnityEngine.Events;

namespace Combat
{
    public class CombatTarget : MonoBehaviour
    {
        [SerializeField] private CombatMaterial combatMaterial;
        [SerializeField] private float health = 20f;
        [SerializeField] private float maxHealth = 20f;
        [SerializeField] private UnityEvent onDestroy;

        public CombatMaterial CombatMaterial => combatMaterial;
        public float Health => health;
        public float MaxHealth => maxHealth;
        
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
            onDestroy.Invoke();
            Destroy(gameObject);
        }
    }
}
