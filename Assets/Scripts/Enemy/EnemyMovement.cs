using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    Transform player;
    //PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    NavMeshAgent nav;


    void Awake ()
    {
        //player = GameObject.FindGameObjectWithTag ("Player").transform;
        
        //playerHealth = player.GetComponent <PlayerHealth> ();
        //enemyHealth = GetComponent <EnemyHealth> ();
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

            if(distance < lastDistance)
            {
                lastDistance = distance;
                player = players[i].transform;
            }
        }

    }

    void Update ()
    {
        changePlayer();
        //if(enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        //{
            nav.SetDestination (player.position);
        //}
        //else
        //{
        //    nav.enabled = false;
        //}
    }
}
