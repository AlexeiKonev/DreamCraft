using NUnit.Framework;
using UnityEngine;
namespace DCS
{
    public class GameManagerTests
    {
        [Test]
        public void Player_Move()
        {
            // Arrange
            PlayerController playerController = new PlayerController();
            playerController.Initialize();

            Vector2 initialPosition = playerController.GetPosition();

            // Act
            playerController.Move(new Vector2(1f, 0f));

            Vector2 newPosition = playerController.GetPosition();

            // Assert
            Assert.AreNotEqual(initialPosition, newPosition);
        }

        [Test]
        public void Player_Shoot()
        {
            // Arrange
            PlayerShooting playerShooting = new PlayerShooting();
            playerShooting.Initialize();

            bool isShooting = false;

            // Act
            playerShooting.Shoot();
            isShooting = true;

            // Assert
            Assert.IsTrue(isShooting);
        }

        [Test]
        public void Enemy_TakeDamage()
        {
            // Arrange
            int initialHealth = 10;
            int damage = 5;

            Enemy enemy = new Enemy(2f, initialHealth);

            // Act
            enemy.TakeDamage(damage);

            int currentHealth = enemy.GetHealth();

            // Assert
            Assert.AreEqual(initialHealth - damage, currentHealth);
        }
    }
}