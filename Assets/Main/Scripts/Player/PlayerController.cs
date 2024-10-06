using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class PlayerController : MonoBehaviour
    {
        public Utilities.PlayerInfoType infoType;
        public Animator animator;
        public Collider2D box;
        public StateMachine stateMachine;
        public PlayerInput playerInput;


        private void Awake()
        {
            animator = GetComponentInChildren<Animator>();
            box = GetComponent<Collider2D>();
            stateMachine = GetComponent<StateMachine>();
            playerInput = GetComponent<PlayerInput>();
        }
    }

}
