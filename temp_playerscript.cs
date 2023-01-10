using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class temp_playerscript : MonoBehaviour
{
    public int collectablesCount = 0;
    public int speed;
    private bool gameWon;
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI loseText;
    public TextMeshProUGUI winText;
    public TextMeshProUGUI countText;
    private float totalTime;
    private float timeLeft;
    private Rigidbody myBody;

    // Start is called before the first frame update
    void Start()
    {
        winText.text = "";
        loseText.text = "";
        countText.text = "Score: ";

        totalTime = 20;
        timeLeft = totalTime;
        gameWon = false;
        timerText.text = "Timer:" + timeLeft.ToString();

        myBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");		
		float moveVertical = Input.GetAxis("Vertical");        
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		GetComponent<Rigidbody>().AddForce(movement * speed); 

        countText.text = "Score: " + collectablesCount.ToString();

        timerText.text = "Timer:" + timeLeft.ToString();
        if (gameWon == false)
        {
            timeLeft -= Time.deltaTime;
            if(timeLeft < 0)
            {
                loseText.text = "GAME OVER";
                gameObject.SetActive(false);
                timerText.text = "Timer:0.00";
            }
        }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.SetActive (false);
            collectablesCount++;
        }
    }
}
