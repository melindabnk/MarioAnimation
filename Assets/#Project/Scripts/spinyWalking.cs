using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]


public class spinyWalking : MonoBehaviour
{


    public float speed;
    public float sens = 1f;
   


    void Update()
    {
        Move();
    }

   void Move()
    {
        transform.position += speed * Time.deltaTime * transform.right;
    }
    


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
            speed *= -1;
        }
        if (collision.gameObject.CompareTag("ColliderExitLeft"))
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
            speed *= -1;
            
        }
    }


}


