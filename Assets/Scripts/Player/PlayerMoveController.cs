using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerAnimationStateMachine))]
public class PlayerMoveController : MonoBehaviour
{
    [SerializeField] private float _gravity;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _speed;
    [SerializeField] private float _sprintSpeed;

    private float _jspeed;
    private Vector3 _movementDirection;
    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();

    }

    private void Update()
    {
        float speed = _speed;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (_characterController.isGrounded)
        {
            _jspeed = 0f;

            if (horizontal != 0f || vertical != 0f)
            {
                _movementDirection = new Vector3(horizontal, 0f, vertical);
            }

            if (Input.GetKey(KeyCode.Space))
            {
                _jspeed = _jumpForce;
            }
            if(Input.GetKey(KeyCode.LeftShift))
            {
                speed = _sprintSpeed;
            }
        }
        _jspeed += _gravity * Time.deltaTime * 3f;
        Vector3 dir = new Vector3(horizontal * speed * Time.deltaTime, _jspeed * Time.deltaTime, vertical * speed * Time.deltaTime);
        _characterController.Move(dir);
    }
}

