using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropItem : MonoBehaviour
{
    private Vector3 startPosition;    // 初始位置
    public  Vector3 endPosition;      // 目標位置
    public  float   totalTime = 3.0f; // 移動到指定位置的總時間

    private float elapsedTime = 0.0f;

    private void Awake()
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
        elapsedTime        = 0.0f;
        transform.position = startPosition;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("Fail");
        }
    }
}