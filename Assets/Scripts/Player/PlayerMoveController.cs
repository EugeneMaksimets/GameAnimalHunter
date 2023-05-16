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
    private CharacterController _characterController;
    private PlayerAnimationStateMachine _playerAnimationStateMachine;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
        _playerAnimationStateMachine = GetComponent<PlayerAnimationStateMachine>();

    }

    private void Update()
    {
        float speed = _speed;
        float horizontal = 0f;
        float vertical = 0f;
        if(_characterController.isGrounded)
        {
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            _jspeed = 0f;
            if(Input.GetKey(KeyCode.Space))
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

