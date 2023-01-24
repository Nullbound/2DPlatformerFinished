//this script depends on the fact that there are 12 collectibles at the start of the level.
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class Portal : MonoBehaviour
{
    public static Portal instance;

    //Assigning names to the door animation states and the collider
    private Animator anim;
    private BoxCollider2D box;

    //this variable will be used in both the door object and the collectables we will use it to trigger the opening of the door
    [HideInInspector]
    public int collectiblesCount;
    public TextMeshProUGUI countText;
    public TextMeshProUGUI winText;
    // public GameObject next;
    // Use this for initialization
    void Awake()
    {
        //This creates the door instance
        MakeInstance();
        //This loads its default animation state
        anim = GetComponent<Animator>();
        //this gets its BoxCollider state and packages it in a variable called box
        box = GetComponent<BoxCollider2D>();
        winText.text = "";
        countText.text = "";
        collectiblesCount = collectiblesCount - 5;
        // next.gameObject.SetActive(false);
        
    }

    void MakeInstance()
    {
        //this creates the door in the frame
        if (instance == null)
            instance = this;

    }
    //This is a function that lowers the value of collectiblesCount which will be used in the collectible objects
    public void DecrementCollectibles()
    {
        //lower the value of collectiblesCount by one
        collectiblesCount++;

        countText.text = "Void Crystals:" + collectiblesCount.ToString() + "/5";
        //check to see if the value of collectiblesCount has reached 0
        if (collectiblesCount == 5)
        {
            //if there are no more collectibles on the scene, begin the OpenDoor coroutine
            StartCoroutine(OpenDoor());
            winText.text = "Singularity Opening!";
            StartCoroutine(StopText());
        }
    }

    //This function switches the animation state of the door from Idle to Open and turns on the box trigger to see if the player touches the door
    IEnumerator OpenDoor()
    {
        anim.Play("Open");
        yield return new WaitForSeconds(.7f);
        //turns the trigger of the Door boxCollider on
        box.isTrigger = true;
    }
    IEnumerator StopText()
    {
        yield return new WaitForSeconds(3f);
        winText.text = "";
    }
    //this constantly checks for a collision with the Player object
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Player")
        {
            //if a collision with the player occurs, do this.  This can be used to load the next scene.
            Debug.Log("Level Finished");
            // next.gameObject.SetActive(true);
            SceneManager.LoadScene("Lvl_2");

        }
    }
}