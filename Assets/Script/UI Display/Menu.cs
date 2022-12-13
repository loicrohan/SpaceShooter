using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Menu : MonoBehaviour
{
    public void ClickStart()
    {
        SceneManager.LoadScene("2LevelSelect");
    }
}
