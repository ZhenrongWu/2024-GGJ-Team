using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    
    public UnityEvent onTimerStart;
    
    void Start()
    {
        ring = GetComponent<Image>();
        toyz = FindObjectOfType<Toyz>();
        animator = toyz.GetComponent<Animator>();
        
        // 開始計時
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

            if (Input.GetMouseButtonDown(0))
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
            onTimerStart?.Invoke();
            

            // win
        }
        
    }
    
}
