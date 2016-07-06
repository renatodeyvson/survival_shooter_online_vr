using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class EnemyMovement : MonoBehaviour
    {
        Transform player;               // Reference to the player's position.
        PlayerHealth playerHealth;      // Reference to the player's health.
        EnemyHealth enemyHealth;        // Reference to this enemy's health.
        NavMeshAgent nav;               // Reference to the nav mesh agent.


        void Awake ()
        {
            // Set up the references.
            player = GameObject.FindGameObjectWithTag ("Player").transform;
            playerHealth = player.GetComponent <PlayerHealth> ();
            enemyHealth = GetComponent <EnemyHealth> ();
            nav = GetComponent <NavMeshAgent> ();
        }

        void changePlayer()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            float lastDistance = float.MaxValue;
            for (int i = 0; i < players.Length; i++)
            {
                float x = transform.position.x - players[i].transform.position.x;
                float z = transform.position.z - players[i].transform.position.z;

                float distance = Mathf.Sqrt(Mathf.Pow(x, 2) + Mathf.Pow(z, 2));

                if (distance < lastDistance)
                {
                    lastDistance = distance;
                    player = players[i].transform;
                }
            }

        }

        void Update ()
        {
            changePlayer();
            // If the enemy and the player have health left...
            if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
            {
                // ... set the destination of the nav mesh agent to the player.
                nav.SetDestination (player.position);
            }
            // Otherwise...
            else
            {
                // ... disable the nav mesh agent.
                nav.enabled = false;
            }
        }
    }
}