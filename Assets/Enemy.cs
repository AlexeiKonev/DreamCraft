using System;
using UnityEngine;
namespace DCS
{
    // Класс для врагов
    public class Enemy : IMovable, IDamageable
    {
        private Vector2 position;
        private float moveSpeed;
        private int health;

        public event Action<Enemy> OnEnemyDestroyed;

        public Enemy(float speed, int maxHealth)
        {
            position = Vector2.zero;
            moveSpeed = speed;
            health = maxHealth;
        }

        public int GetHealth()
        {
            return health;
        }

        public void Move(Vector2 direction)
        {
            position += direction * moveSpeed * Time.deltaTime;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            // Логика для уничтожения врага
            // Например, остановка анимации, воспроизведение звука и т.д.

            // Вызываем событие OnEnemyDestroyed, передавая текущий объект в качестве аргумента
            OnEnemyDestroyed?.Invoke(this);
        }

        internal void SetPosition(Vector3 vector3)
        {
            throw new NotImplementedException();
        }
    }





}
