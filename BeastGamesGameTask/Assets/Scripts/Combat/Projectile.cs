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
        [SerializeField] private float damage;
        [SerializeField] private CombatMaterial combatMaterial;

        private Rigidbody _rigidbody;
        private Vector3 _destinationVector;
        private IObjectPool<Projectile> _projectilePool;

        public float Damage => damage;
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

        private void SetDamage(float damage) =>this.damage = damage;

        private void OnTriggerEnter(Collider other)
        {
            if (hitEffect != null)
            {
                Instantiate(hitEffect, other.transform.position, Quaternion.identity);
            }

            var combatTarget = other.GetComponent<CombatTarget>();
            if (combatTarget != null && combatTarget.CombatMaterial == combatMaterial)
            {
                combatTarget.TakeDamage(damage);
            }
            
            _projectilePool.Release(this);
        }
    }
}
