using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerHealth: MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealth = 100f;
    [SerializeField] float invulnerabilityDuration = 1f;
    [SerializeField] float blinkInterval = 0.1f;

    public float currentHealth;
    
    private float invulnerabilityTimer;

    private SpriteRenderer Sprite;
    private float blinkTimer;
    private bool blinking;
    public Slider healthSlider;

    void Awake()
    {
        currentHealth = maxHealth;
        Sprite = GetComponent<SpriteRenderer>();
        
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = currentHealth;
        }
    }
    void Update()
    {
        if(invulnerabilityTimer > 0f)
        {
            invulnerabilityTimer-=Time.deltaTime;
            HandleBlink();
        }
    }
    public bool ApplyDamage(float amount)
    {
        if(currentHealth <=0f || invulnerabilityTimer >0f)
        return false;

        currentHealth -= amount;
        if(healthSlider != null)
        healthSlider.value = currentHealth;
        {
            Die();
            return true;
        }
        invulnerabilityTimer = invulnerabilityDuration;
        StartBlink(invulnerabilityDuration);
        return true;
    }
    void StartBlink(float duration)
    {
        blinking = true;
        blinkTimer = duration;
    }
    void HandleBlink()
    {
        if(!blinking) 
        {
            return;
        }
        blinkTimer -= Time.deltaTime;
        if(blinkTimer <= 0f)
        {
            blinking = false;
            Sprite.enabled = true;
            return;
        }
        Sprite.enabled =
        Mathf.FloorToInt(blinkTimer/blinkInterval) % 2 == 0;
    }
    void Die()
    {
        gameObject.SetActive(false);
    }
    }