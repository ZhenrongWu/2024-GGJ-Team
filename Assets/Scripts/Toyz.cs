using System.Collections.Generic;
using UnityEngine;

public class Toyz : MonoBehaviour
{
    public List<GameObject> childs;

    public void HideChild()
    {
        foreach (var c in childs)
        {
            c.SetActive(false);
        } 
    }
}