using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(2);

        Instantiate(bullet , transform.position , Quaternion.identity);
        StartCoroutine(Attack());
    }
}
