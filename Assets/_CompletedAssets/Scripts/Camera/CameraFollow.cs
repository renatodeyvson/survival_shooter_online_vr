using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

namespace CompleteProject
{
    public class CameraFollow : NetworkBehaviour
    {

        public Transform target;            // The position that that camera will be following.
        //public float smoothing = 5f;        // The speed with which the camera will be following.


        //Vector3 offset;                     // The initial offset from the target.


        void Start ()
        {
            // Calculate the initial offset.
            //offset = transform.position - target.position;
        }


        public void getLocalPlayer()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");

            for (int i = 0; i < players.Length; i++)
            {
                if(players[i].GetComponent<NetworkBehaviour>().isLocalPlayer)
                    target = players[i].transform;
            }
        }

        void FixedUpdate ()
        {
            if (target == null) {
                getLocalPlayer();
                return;
            }

            // Create a postion the camera is aiming for based on the offset from the target.
            //Vector3 targetCamPos = target.position + offset;

            // Smoothly interpolate between the camera's current position and it's target position.
            //transform.position = Vector3.Lerp (transform.position, targetCamPos, transform.position.y);

            //Iguala a posição
            Vector3 position = target.position;
            position.y += 1.5f;
            transform.position = position;
            target.rotation = transform.rotation;
        }
    }
}