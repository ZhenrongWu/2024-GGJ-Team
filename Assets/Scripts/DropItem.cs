using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    public Vector3 endPosition; // 目標位置
    public float totalTime = 3.0f; // 移動到指定位置的總時間

    private Vector3 startPosition;
    private float elapsedTime = 0.0f;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        
        elapsedTime += Time.deltaTime;

        if (elapsedTime < totalTime)
        {
            float t = elapsedTime / totalTime; // 插值比例
            transform.position = Vector3.Lerp(startPosition, endPosition, t);
        }
        else
        {
            transform.position = endPosition; // 確保在指定時間內準確到達目標位置
        }
        
    }

    public void Drop()
    {
        elapsedTime = 0.0f;
        transform.position = startPosition;
    }
}
