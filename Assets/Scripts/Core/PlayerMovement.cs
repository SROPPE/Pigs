using Pigs.MapTools;
using UnityEngine;
namespace Pigs.Core
{
    public class PlayerMovement : MonoBehaviour
    {
        [Header("Movement Settings")]
        [SerializeField] private float speed;
        [SerializeField] private FieldAngleHandler angleHandler;
        [Header("Joystick settings")]
        [SerializeField] private Joystick joystick;
        [SerializeField] private float offset = 0.5f;

        private Rigidbody2D rb;
        private Vector2 moveInput = new Vector2();
        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            if (joystick.Horizontal >= offset || joystick.Horizontal <= -offset)
            {
                moveInput.x = joystick.Horizontal;
                moveInput.y = 0;
            }
            else if (joystick.Vertical >= offset || joystick.Vertical <= -offset)
            {
                moveInput.x = joystick.Vertical * Mathf.Tan(angleHandler.AngleInRands);
                moveInput.y = joystick.Vertical;
            }
            else
            {
                moveInput *= 0;
            }
            rb.velocity = moveInput * speed;
        }
    }
}