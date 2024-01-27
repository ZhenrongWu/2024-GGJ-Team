using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QTE : MonoBehaviour
{
    private Toyz toyz;
    private Animator animator;
    [SerializeField] private string triggerName;
    private int hitCount = 0;

    private Image ring;
    private bool isPlaying = false;

    public float maxTime = 3f;
    private float timer;
    
    public UnityEvent onTimerStart; // 用在dropItem
    
    
    void Start()
    {
        ring = GetComponent<Image>();
        toyz = FindObjectOfType<Toyz>();
        animator = toyz.GetComponent<Animator>();
        
        // 開始計時
        timer = maxTime;
        ring.fillAmount = 1;
        onTimerStart?.Invoke();
        
        isPlaying = true;
    }

    
    void Update()
    {
        if (isPlaying)
        {
            timer -= Time.deltaTime;
            ring.fillAmount = timer / maxTime;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var c in toyz.childs)
                {
                    c.SetActive(true);
                }
                
                animator.SetTrigger(triggerName);
                hitCount++;
                
                // 開始計時
                timer = maxTime;
                ring.fillAmount = 1;
                onTimerStart?.Invoke();
            }
            
            if (timer <= 0)
            {
                isPlaying = false;
                timer = 0;
                ring.fillAmount = 0;
                SceneManager.LoadScene("Fail");
            }
        }

        if (hitCount >= 4)
        {
            isPlaying = false;
            timer = 0;
            ring.gameObject.SetActive(false);
            
            // win
        }
        
    }
    
}
