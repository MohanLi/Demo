using UnityEngine;
using System.Collections;

public class MyPlayerShooting : MonoBehaviour {
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    float effectsDisplayTime = 0.2f;
    float timer;
    int shootableMask;

    Ray shootRay;
    RaycastHit shootHit;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    
    void Awake()
    {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLight = GetComponent<Light>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButton("Fire1") && timer >= timeBetweenBullets && Time.time != 0f)
        {
            Shoot();
        }

        if (timer > effectsDisplayTime * timeBetweenBullets)
        {
            EffectsDisabled();
        }
    }

    void EffectsDisabled()
    {
        gunLight.enabled = false;
        gunLine.enabled = false;
    }


    void Shoot()
    {
        timer = 0f;

        //播放音效
        gunAudio.Play();
        //显示灯光
        gunLight.enabled = true;

        //播放粒子效果
        gunParticles.Stop();
        gunParticles.Play();

        //显示gunLine并设置其位置
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);//0表示第一个顶点

        //设置射线的起始位置和方向
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;


        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            MyEnemyHealth enemyHealth = shootHit.collider.GetComponent<MyEnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, shootHit.point);
            }
            gunLine.SetPosition(1, shootHit.point);//1表示第二个顶点
        }
        else
        {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
