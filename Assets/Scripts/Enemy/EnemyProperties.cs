using System;
using UnityEngine;

namespace Enemy
{
    public class EnemyProperties : MonoBehaviour
    {
        public float health;
        public float damage;
        public float attackCooldown;
        public float attackTimer;
        public float rewardEvoPoints;
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
            attackTimer += Time.deltaTime;
        }

        public void TakeDamage(float damageTaken)
        {
            EnemyDamageTakeBehavior.TakeDamage(damageTaken, this);
        }

        public void EnemyDie()
        {
            HUD.Instance.IncreaseEvolutionPoints(rewardEvoPoints);
            EnemyDeathBehavior.Die(gameObject);
        }

        public void AttackPlayer(EnemyAttackInformation enemyAttackInformation)
        {
            if (attackTimer >= attackCooldown)
            {
                attackTimer = 0f;
                EnemyAttackBehavior.AttackPlayer(enemyAttackInformation);
            }
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