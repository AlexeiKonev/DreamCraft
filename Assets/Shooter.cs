using UnityEngine;
namespace DCS
{
    // Интерфейс для контроллеров игровых объектов
    public interface IController
    {
        void Initialize();
        void Update();
    }

    // Интерфейс для игровых объектов, которые могут быть повреждены
    public interface IDamageable
    {
        void TakeDamage(int damage);
    }

    // Интерфейс для объектов, которые могут стрелять
    public interface IShooter
    {
        void Shoot();
    }

    // Интерфейс для объектов, которые могут двигаться
    public interface IMovable
    {
        void Move(Vector2 direction);
    }

    // Класс для управления игроком
    public class PlayerController : IController, IMovable
    {
        private Vector2 position;
        private float moveSpeed;

        public void Initialize()
        {
            position = Vector2.zero;
            moveSpeed = 5f;
        }

        public void Update()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            Move(new Vector2(horizontalInput, verticalInput));
        }

        public void Move(Vector2 direction)
        {
            position += direction * moveSpeed * Time.deltaTime;
        }

        public Vector2 GetPosition()
        {
            return position;
        }
    }

    // Класс для стрельбы игрока
    public class PlayerShooting : IController, IShooter
    {
        private GameObject bulletPrefab;
        private Transform weaponTransform;
        private bool isShooting;

        public void Initialize()
        {
            bulletPrefab = Resources.Load<GameObject>("BulletPrefab");
            weaponTransform = GameObject.Find("Weapon").transform;

            isShooting = false;
        }


        public void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                isShooting = true;
                Shoot();
            }

            if (Input.GetMouseButtonUp(0))
            {
                isShooting = false;
            }
        }

        public void Shoot()
        {
            if (!isShooting) return;

            GameObject bullet = Object.Instantiate(bulletPrefab, weaponTransform.position, weaponTransform.rotation);
            Object.Destroy(bullet, 2f);
        }
    }

    // Класс для пуль
    public class Bullet : IMovable
    {
        private Vector2 position;
        private Vector2 direction;
        private float moveSpeed;
        private int damage;

        public Bullet(Vector2 startPos, Vector2 dir, float speed, int dmg)
        {
            position = startPos;
            direction = dir.normalized;
            moveSpeed = speed;
            damage = dmg;
        }

        public void Move(Vector2 direction)
        {
            position += direction * moveSpeed * Time.deltaTime;
        }

        public Vector2 GetPosition()
        {
            return position;
        }

        public int GetDamage()
        {
            return damage;
        }
    }

    // Класс для спавна врагов
    public class EnemySpawner : IController
    {
        private float spawnTimer;
        private float spawnInterval;
        private GameObject enemyPrefab;

        public void Initialize()
        {
            spawnTimer = 0f;
            spawnInterval = 2f;

            // Загрузка префаба врага из ресурсов (или другим способом)
            enemyPrefab = Resources.Load<GameObject>("EnemyPrefab");
        }

        public void Update()
        {
            spawnTimer += Time.deltaTime;

            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0f;
            }
        }

        private void SpawnEnemy()
        {
            // Создание экземпляра врага с помощью Instantiate
            GameObject enemyObject = Object.Instantiate(enemyPrefab);

            // Дополнительная логика для размещения врага на сцене, например, установка его позиции
            enemyObject.transform.position = GetRandomSpawnPosition();
        }

        private Vector3 GetRandomSpawnPosition()
        {
            // Логика для получения случайной позиции спавна врага
            // Например, можно использовать Random.Range() для задания случайных координат

            return new Vector3(/* случайные координаты */);
        }
    }


    public class EnemyFactory
    {
        public Enemy CreateEnemy()
        {
            // Логика для создания экземпляра врага
            // Например, можно использовать new Enemy() или объект-пул для повторного использования врагов

            return new Enemy( 3f,3);
        }
    }





}
