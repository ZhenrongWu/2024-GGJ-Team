using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseFoodSceneTransition : MonoBehaviour
{
    

    public void NextLevel()
    {
        SceneManager.LoadScene("ChooseAttack");
    }
    
    public void Fail()
    {
        SceneManager.LoadScene("Fail");
    }
    
}
