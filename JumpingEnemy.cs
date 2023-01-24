using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingEnemy : MonoBehaviour
{
    public float forceY = 300f;
    private Rigidbody2D myRigidbody;
    private Animator myAnimator;

    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody2D> ();
        myAnimator = GetComponent<Animator> ();
    }
    // Use this for initialization

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds (Random.Range (2 , 4));
        forceY = Random.Range (250 , 550);
        myRigidbody.AddForce(new Vector2(0 , forceY));
        myAnimator.SetBool ("attack" , true);
        yield return new WaitForSeconds (1.5f);
        myAnimator.SetBool ("attack" , false);
        StartCoroutine (Attack ());
    }

}
