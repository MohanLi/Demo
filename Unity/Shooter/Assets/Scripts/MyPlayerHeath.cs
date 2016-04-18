using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MyPlayerHeath : MonoBehaviour {
    public int startingHealth = 100;
    public int currentHealth;
    public Image damageImage;
    public Slider heathSlider;
    public AudioClip deathClip;
    public float flashSpeed = 5f;
    public Color flashColor = new Color(1f, 0f, 0f, 0.1f);

    Animator anim;
    AudioSource playerAudio;
    MyPlayerMovement playerMovenment;

    bool isDead;
    bool damaged;
    
    void Awake()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovenment = GetComponent<MyPlayerMovement>();
        currentHealth = startingHealth;
    }

    void Update()
    {
        if (damaged)
        {
            //damageImage.color = flashColor;
        }
        else
        {
            //damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
        }
        damaged = false;
    }

    public void TakeDamage(int amount)
    {
        damaged = true;
        currentHealth -= amount;
        heathSlider.value = currentHealth;
        playerAudio.Play();

        if (currentHealth <= 0 && !isDead)
        {
            Dead();
        }
    }

    void Dead()
    {
        isDead = true;
        anim.SetTrigger("Dead");

        playerAudio.clip = deathClip;
        playerAudio.Play();

        playerMovenment.enabled = false;
    }

    public void RestartLevel()
    {
        //Application.LoadLevel(Application.loadedLevel);
    }
}
