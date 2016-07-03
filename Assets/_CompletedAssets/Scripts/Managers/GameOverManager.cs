using UnityEngine;

namespace CompleteProject
{
    public class GameOverManager : MonoBehaviour
    {
       // public PlayerHealth playerHealth;       // Reference to the player's health.


        Animator anim;                          // Reference to the animator component.


        void Awake ()
        {
            // Set up the reference.
            anim = GetComponent <Animator> ();
        }

        public bool isGameOver()
        {
            bool gameOver = false;
            GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player");

            for (int i = 0; i < playerList.Length; i++)
            {
                gameOver = gameOver || playerList[i].GetComponent<PlayerHealth>().currentHealth <= 0;
            }
            return gameOver;
        }

        void Update ()
        {

            // If the player has run out of health...
            if (isGameOver())
            {
                // ... tell the animator the game is over.
                anim.SetTrigger ("GameOver");
            }
        }
    }
}