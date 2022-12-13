using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    
    public void SelectRocks()
    {
        SceneManager.LoadScene("3RockLevel");
    }

    
    public void SelectEnemyJet()
    {
        SceneManager.LoadScene("4JetLevel");
    }
}
