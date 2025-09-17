using UnityEngine;
using UnityEngine.InputSystem;

public class LuigiMovement : MonoBehaviour
{

    public float speed;
    [SerializeField] private InputActionAsset actions;
    [SerializeField] InputAction moveRight;
    [SerializeField] InputAction moveLeft;

    [SerializeField] InputAction jump;
    bool canJump;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        moveRight = actions.FindActionMap("NewActionMap").FindAction("MoveRight");
        moveLeft = actions.FindActionMap("NewActionMap").FindAction("MoveRight");

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveRight();
    }

    void MoveRight()
    {
        float MoveR = moveRight.ReadValue<float>();
        transform.position += speed * Time.deltaTime * MoveR * transform.right;

    }
}
