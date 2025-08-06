using System;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

namespace Controller
{
    [RequireComponent(typeof(CreatureMover))]
    public class MovePlayerInput : MonoBehaviour
    {
        [SerializeField] CreatureMover m_Mover;
        [SerializeField] GameObject player;

        //[Header("Character")]
        //[SerializeField]
        //private string m_HorizontalAxis = "Horizontal";
        //[SerializeField]
        //private string m_VerticalAxis = "Vertical";
        //[SerializeField]
        //private string m_JumpButton = "Jump";
        //[SerializeField]
        //private KeyCode m_RunKey = KeyCode.LeftShift;

        //[Header("Camera")]
        //[SerializeField]
        //private PlayerCamera m_Camera;
        //[SerializeField]
        //private string m_MouseX = "Mouse X";
        //[SerializeField]
        //private string m_MouseY = "Mouse Y";
        //[SerializeField]
        //private string m_MouseScroll = "Mouse ScrollWheel";

        private Vector2 m_Axis;
        private bool m_IsRun;
        //private bool m_IsJump;

        public Vector3 m_Target;
        //private Vector2 m_MouseDelta;
        //private float m_Scroll;

        private void Awake()
        {
            m_Mover = GetComponent<CreatureMover>();
            player = GameObject.FindGameObjectWithTag("Player");
            m_Target = player.transform.position;
        }

        private void Update()
        {
            //GatherInput();
            SetInput();
        }

        //public void GatherInput()
        //{
        //    m_Axis = new Vector2(Input.GetAxis(m_HorizontalAxis), Input.GetAxis(m_VerticalAxis));
        //    m_IsRun = Input.GetKey(m_RunKey);
        //    m_IsJump = Input.GetButton(m_JumpButton);

        //    //m_Target = (m_Camera == null) ? Vector3.zero : m_Camera.Target;
        //    m_MouseDelta = new Vector2(Input.GetAxis(m_MouseX), Input.GetAxis(m_MouseY));
        //    m_Scroll = Input.GetAxis(m_MouseScroll);
        //}

        public void GatherInputSample(Vector2 vec2, bool isrun)
        {
            m_Axis = vec2;
            m_IsRun = isrun;
        }

        public void BindMover(CreatureMover mover)
        {
            m_Mover = mover;
        }

        public void GatherInputSample(Vector2 vec2, bool isrun, Vector3 position)
        {
            m_Axis = vec2;
            m_IsRun = isrun;
            position.z = transform.position.z;
            m_Target = position;
        }

        internal void SetSpeed(Vector2 speed)
        {
            m_Mover.SetMovement(speed);
        }

        public void SetInput()
        {
            if (m_Mover != null)
            {
                m_Mover.SetInput(in m_Axis, in m_Target, in m_IsRun);
            }

            //if (m_Camera != null)
            //{
            //    m_Camera.SetInput(in m_MouseDelta, m_Scroll);
            //}
        }
    }
}