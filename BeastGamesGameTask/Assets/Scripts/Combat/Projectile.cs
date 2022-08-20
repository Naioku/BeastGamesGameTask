using System.Collections;
using Core;
using UnityEngine;
using UnityEngine.Pool;

namespace Combat
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private GameObject hitEffect;
        [SerializeField] private float maxLifeTime = 10f;
        [SerializeField] private CombatMaterial combatMaterial;

        private float _damage;
        private Rigidbody _rigidbody;
        private Vector3 _destinationVector;
        private IObjectPool<Projectile> _projectilePool;

        public float Damage => _damage;
        public CombatMaterial CombatMaterial => combatMaterial;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            _rigidbody.velocity = _destinationVector * speed;
        }

        public void SetPool(IObjectPool<Projectile> projectilePool) => _projectilePool = projectilePool;
        
        public IEnumerator PrepareProjectile(Vector3 destinationPoint, Vector3 firePoint, float damage)
        {
            SetProjectileDirection(destinationPoint, firePoint);
            SetDamage(damage);
            
            yield return new WaitForSecondsRealtime(maxLifeTime);

            if (gameObject.activeSelf)
            {
                _projectilePool.Release(this);
            }
        }

        private void SetProjectileDirection(Vector3 destinationPoint, Vector3 firePoint)
        {
            transform.LookAt(destinationPoint);
            _destinationVector = (destinationPoint - firePoint).normalized;
        }

        private void SetDamage(float damage) =>_damage = damage;

        private void OnTriggerEnter(Collider other)
        {
            var combatTarget = other.GetComponent<CombatTarget>();
            if (combatTarget != null && combatTarget.CombatMaterial == combatMaterial)
            {
                combatTarget.TakeDamage(_damage);
                if (hitEffect != null)
                {
                    Instantiate(hitEffect, transform.position, Quaternion.identity);
                }
            }
            
            _projectilePool.Release(this);
        }
    }
}
