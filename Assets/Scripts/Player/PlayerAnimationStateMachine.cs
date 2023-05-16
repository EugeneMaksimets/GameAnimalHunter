using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerMoveController))]
[RequireComponent(typeof(Health))]
public class PlayerAnimationStateMachine : MonoBehaviour
{
    private Animator _animator;
    private CharacterController _characterController;
    private string _currentState;
    private Health _health;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _characterController = GetComponent<CharacterController>();
        _health = GetComponent<Health>();

    }

    private void Update()
    {
        Vector3 movement = _characterController.velocity;
        float movementSpeed = movement.magnitude;

        if (movementSpeed > 0f && movementSpeed < 3f && _currentState != "Walk")
        {
            ChangeState("Walk");
            print(movementSpeed);
        }
        else if (movementSpeed == 0f && _currentState != "Idle" && !_health.Death)
        {
            ChangeState("Idle");
        }
        else if (movementSpeed > 4f && _currentState != "Run")
        {
            ChangeState("Run");
        }
        else if (Input.GetMouseButton(0) && _currentState != "AttackSword")
        {
            ChangeState("AttackSword");
        }
        else if (Input.GetKeyDown(KeyCode.Z) && _currentState != "Defend")
        {
            ChangeState("Defend");
        }
        else if (_health._Health <= 0)
        {
            ChangeState("Die");
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    ChangeState("Jump");
        //}
    }

    private void ChangeState(string newState)
    {
        if (newState == _currentState)
            return;

        if (_currentState != null)
        {
            _animator.SetBool(_currentState, false);
        }

        _animator.SetBool(newState, true);
        _currentState = newState;
    }

}
