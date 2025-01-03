using UnityEngine;

public class ChickenController : MonoBehaviour
{
    private enum ChickenState
    {
        IDLE,
        RUN,
        EAT,
    }

    public Animator chickenAnim;
    public float    moveSpeed = 5f;
    public float    rotationSpeed = 10f;
    
    private ChickenState _state;
    private Vector3      _moveDirection;

    private ChickenState State
    {
        get => _state;
        set
        {
            _state = value;

            switch (State)
            {
                case ChickenState.IDLE:
                    OnIdle();
                    break;
                case ChickenState.RUN:
                    OnRun();
                    break;
                case ChickenState.EAT:
                    OnEat();
                    break;
            }
        }
    }

    void OnIdle()
    {
        chickenAnim.SetBool("IsRun", false);
    }

    void OnRun()
    {
        // 이동 방향으로 위치 변경
        transform.Translate(_moveDirection * moveSpeed * Time.deltaTime, Space.World);

        // 이동 방향으로 회전
        Quaternion targetRotation = Quaternion.LookRotation(_moveDirection);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        chickenAnim.SetBool("IsRun", true);
    }

    void OnEat()
    {
        chickenAnim.SetTrigger("Eat");
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal"); // A, D 키
        float vertical = Input.GetAxis("Vertical");     // W, S 키
        
        _moveDirection = new Vector3(horizontal, 0f, vertical).normalized;
        
        State = _moveDirection.magnitude >= 0.1f ? ChickenState.RUN : ChickenState.IDLE;

        if (Input.GetKeyDown(KeyCode.Space))
            State = ChickenState.EAT;
    }
}