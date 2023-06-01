using UnityEngine;
namespace DCS
{
    // Класс для управления игрой
    public class GameManager : MonoBehaviour
    {
        private PlayerController playerController;
        private PlayerShooting playerShooting;
        private EnemySpawner enemySpawner;

        private static GameManager instance;
        public static GameManager Instance
        {
            get { return instance; }
        }

        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
        }

        private void Start()
        {
            playerController = new PlayerController();
            playerShooting = new PlayerShooting();
            enemySpawner = new EnemySpawner();

            playerController.Initialize();
            playerShooting.Initialize();
            enemySpawner.Initialize();
        }

        private void Update()
        {
            playerController.Update();
            playerShooting.Update();
            enemySpawner.Update();
        }
        
    }

   
     

}
