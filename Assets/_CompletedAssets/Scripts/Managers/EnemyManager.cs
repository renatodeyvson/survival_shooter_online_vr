using UnityEngine;
using UnityEngine.Networking;

namespace CompleteProject
{
    public class EnemyManager : NetworkBehaviour
    {
        public PlayerHealth playerHealth;       // Reference to the player's heatlh.
        public GameObject enemy;                // The enemy prefab to be spawned.
        public float spawnTime = 3f;            // How long between each spawn.
        public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
        public const int MONSTER_GROUP = 3;

        public bool isCalling = false;

        void Update()
        {
            // Call the Spawn function after a delay of the spawnTime and then continue to call after the same amount of time.
            
            if (!isCalling)
            {
                GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
                if (players.Length > 1 && isServer)
                {
                    InvokeRepeating("Spawn", spawnTime, spawnTime);
                    isCalling = true;
                }
            }

        }

        void Spawn ()
        {
            // If the player has no health left...
            GameOverManager gameOver = GameObject.FindObjectOfType<GameOverManager>();
            if(gameOver.isGameOver())
            {
                // ... exit the function.
                return;
            }

            // Find a random index between zero and one less than the number of spawn points.
            int spawnPointIndex = Random.Range (0, spawnPoints.Length);
            GameObject go = (GameObject)GameObject.Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            // Create an instance of the enemy prefab at the randomly selected spawn point's position and rotation.
            NetworkServer.Spawn(go);
        }
    }
}