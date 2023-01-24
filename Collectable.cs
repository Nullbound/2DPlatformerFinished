using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(Portal.instance != null)
        {
            Portal.instance.collectiblesCount++;
        }
    }
    //This continuously checks for collision with the player and if it occurs, the collectible is unloaded and DecrementCollectibles function is run
    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            Destroy(gameObject);
            if(Portal.instance != null)
            {
                Portal.instance.DecrementCollectibles();
            }
        }
    }
}
