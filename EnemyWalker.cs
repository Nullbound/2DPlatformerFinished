using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2f;

    Rigidbody2D myRigidbody;

    void start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (IsFacingRight())
        {
            myRigidbody.velocity = new Vector2(moveSpeed , 0f);
        }
        else
        {
            myRigidbody.velocity = new Vector2(-moveSpeed , 0f);
        }
    }

    private bool IsFacingRight()
    {
        return transform.localScale.x > Mathf.Epsilon;
    }

    private void OnTriggerExit2D()
    {
        transform.localScale = new Vector2(-(Mathf.Sign(myRigidbody.velocity.x)) , transform.localScale.y);
    }
}   