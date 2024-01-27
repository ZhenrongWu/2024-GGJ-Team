using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QTE : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] string triggerName;
    private int hitCount = 0;

    private Image ring;
    private bool isPlaying = false;

    public float maxTime = 3f;
    private float timer;
    
    
    void Start()
    {
        ring = GetComponent<Image>();
        timer = maxTime;
        ring.fillAmount = 1;
        
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
                animator.SetTrigger(triggerName);
                hitCount++;
                
                timer = maxTime;
                ring.fillAmount = 1;
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
