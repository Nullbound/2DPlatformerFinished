using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public int score = 0;

    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI loseText;

    void Start ()
    {
        rb = GetComponent<Rigidbody> ();

        //winText.text = "";
        //loseText.text = "";
        countText.text = "";
    }

    void FixedUpdate ()
    {
        float moveHorizontal = Input.GetAxis ("Horizontal");
        float moveVertical = Input.GetAxis ("Vertical");

        Vector3 movement = new Vector3 (moveHorizontal,0,moveVertical);

        rb.AddForce (movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive (false);
            score++;
            countText.text = "" + score;
            //Debug.Log("score = " + score);
        }
    }
}
