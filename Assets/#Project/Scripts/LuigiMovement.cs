using System;
using UnityEditor.Build.Content;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;


public class LuigiMovement : MonoBehaviour
{

    public float speed;

    [SerializeField] InputAction moveRight;
    [SerializeField] InputAction moveLeft;

    [SerializeField] InputAction jump;
    bool canJump;
    Rigidbody2D rb;
    public GameObject luigi;
    public Animator anim;
    private SpriteRenderer sr;

    ObjectType type;




    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();


    }
    void Start()
    {

        moveLeft.Enable();
        moveRight.Enable();



    }

    private void OnDisable()
    {

        moveLeft.Disable();
        moveRight.Disable();

    }


    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (move < 0) sr.flipX = true;
        else if (move > 0) sr.flipX = false;


        anim.SetBool("isRunning", move != 0);

        MoveRight();
        MoveLeft();
    }

    void MoveRight()
    {
        float MoveR = moveRight.ReadValue<float>();
        transform.position += speed * Time.deltaTime * MoveR * transform.right;


    }
    void MoveLeft()
    {
        float MoveL = moveLeft.ReadValue<float>();
        transform.position += speed * Time.deltaTime * MoveL * -transform.right;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Objectidentifier id = collision.gameObject.GetComponent<Objectidentifier>();
        if (id == null) return;

        switch (id.type)
        {
            case ObjectType.Wall:
                Debug.Log("Touché mur");
                break;


        }


    }
}
