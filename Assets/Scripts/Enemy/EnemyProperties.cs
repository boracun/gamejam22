using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyProperties : MonoBehaviour
    {
        public float health;
        public float damage;
        public float attackCooldown;
        public EnemyType enemyType;

        public IEnemyDamageTakeBehavior EnemyDamageTakeBehavior;
        public IEnemyDeathBehavior EnemyDeathBehavior;
        public IEnemyAttackBehavior EnemyAttackBehavior;

        public void Start()
        {
            switch (enemyType)
            {
                case EnemyType.NormalEnemy:
                    EnemyDamageTakeBehavior = new NormalDamageTake();
                    EnemyDeathBehavior = new NormalDeath();
                    EnemyAttackBehavior = new NormalAttack();
                    break;
            }
        }

        public void Update()
        {
        }

        public void TakeDamage(float damageTaken)
        {
            EnemyDamageTakeBehavior.TakeDamage(damageTaken, this);
        }

        public void EnemyDie()
        {
            EnemyDeathBehavior.Die(gameObject);
        }

        public void AttackPlayer(EnemyAttackInformation enemyAttackInformation)
        {
            EnemyAttackBehavior.AttackPlayer(enemyAttackInformation);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            GameObject colliderGameObj = other.collider.gameObject;
            if (colliderGameObj.tag.Equals("Panda"))
            {
                EnemyAttackInformation enemyAttackInformation = new EnemyAttackInformation(colliderGameObj, this);
                AttackPlayer(enemyAttackInformation);
            }
        }
    }
}