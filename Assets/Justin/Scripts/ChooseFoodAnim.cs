using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseFoodAnim : MonoBehaviour
{
    [SerializeField] private GameObject buttonParent;
    
    public void ShowButtons()
    {
        buttonParent.SetActive(true);
    }
}
