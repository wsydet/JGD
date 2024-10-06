using System.Collections;
using UnityEngine;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
 

        private WaitForSeconds jumpInputBufferTime;

        private PlayerInputActions playInputActions;

        private Vector2 _axes => playInputActions.GamePlay.Axes.ReadValue<Vector2>();
        public float AxesX => _axes.x == 0 ? 0 : 1 * Mathf.Sign(_axes.x);
        public float AxesY => _axes.y == 0 ? 0 : 1 * Mathf.Sign(_axes.y);
        public bool Up => AxesY > 0;
        public bool Down => AxesY < 0;
        public bool Move => AxesX != 0;


        //public bool HasJumpInputBuffer { get; set; }

       


        private void Awake()
        {
            playInputActions = new PlayerInputActions();
            //jumpInputBufferTime = new WaitForSeconds(0.2f);
        }

        //private void OnEnable()
        //{
        //    playInputActions.GamePlay.Jump.canceled += delegate
        //    {
        //        HasJumpInputBuffer = false;
        //    };
        //}

        public void EnableGamePlayInputs()
        {
            playInputActions.GamePlay.Enable();
            //Cursor.lockState = CursorLockMode.Locked;
        }

        //public void SetJumpInputBuffer()
        //{

        //    StopCoroutine(nameof(JumpInputBufferCoroutine));
        //    StartCoroutine(nameof(JumpInputBufferCoroutine));
        //}

        //IEnumerator JumpInputBufferCoroutine()
        //{
            

        //    HasJumpInputBuffer = true;

        //    yield return jumpInputBufferTime;

        //    HasJumpInputBuffer = false;

            
        //}
    }

}
