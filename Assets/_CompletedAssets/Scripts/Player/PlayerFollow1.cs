using UnityEngine;
using System.Collections;

namespace CompleteProject
{
    public class PlayerFollow1 : MonoBehaviour
    {
        public Transform target;            // The position that that camera will be following.

        void Start()
        {

        }


        void FixedUpdate()
        {
            //Iguala a rotação
            transform.rotation = target.rotation;
        }
    }
}
