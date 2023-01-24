using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlController : MonoBehaviour
{
    public void Lvl1()
    {
        SceneManager.LoadScene("lvl_1");
    }

    public void Lvl2()
    {
        SceneManager.LoadScene("lvl_2");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
