using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace UnityStandardAssets._2D
{
    [RequireComponent(typeof (PlatformerCharacter2D))]
    public class Platformer2DUserControl : MonoBehaviour
    {
        private PlatformerCharacter2D m_Character;
        private bool m_Jump;
        public Text scoretext;
        private int ScoreNum;

        private void Awake()
        {
            m_Character = GetComponent<PlatformerCharacter2D>();
        }

        void Start()
        {
            ScoreNum = 0;
            scoretext.text = "X " + ScoreNum;
        }


        private void Update()
        {
            if (!m_Jump)
            {
                // Read the jump input in Update so button presses aren't missed.
                m_Jump = CrossPlatformInputManager.GetButtonDown("Jump");
            }
        }


        private void FixedUpdate()
        {
            // Read the inputs.
            bool crouch = Input.GetKey(KeyCode.LeftControl);
            float h = CrossPlatformInputManager.GetAxis("Horizontal");
            // Pass all parameters to the character control script.
            m_Character.Move(h, crouch, m_Jump);
            m_Jump = false;
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("coins"))
            {
                ScoreNum += 1;
                Destroy(other.gameObject);
                scoretext.text = "X " + ScoreNum;
            }

            if (other.gameObject.CompareTag("Enemy"))
            {
                SceneManager.LoadScene("cornel-miguel");
            }
        }
    }
}
