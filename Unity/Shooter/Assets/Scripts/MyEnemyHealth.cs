using UnityEngine;
using System.Collections;

public class MyEnemyHealth : MonoBehaviour {
    public int startingHealth = 100;
    public int currentHealth;
    public AudioClip deadClip;

    bool isDead;

    AudioSource audio;
    CapsuleCollider capsuleCollider;
    Animator anim;

    void Awake()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        currentHealth = startingHealth;
    }

    void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Dead();
        }
    }

    void Dead()
    {
        isDead = true;

        audio.clip = deadClip;
        audio.Play();

        anim.SetTrigger("Dead");

        Destroy(gameObject, 2f);
    }
}
