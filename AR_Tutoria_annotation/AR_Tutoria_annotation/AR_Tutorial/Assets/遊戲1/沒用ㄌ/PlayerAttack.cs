using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damagePerShot = 20;                  // 每個子彈造成的傷害
    public float timeBetweenBullets = 0.15f;        // 每次射擊之間的時間
    public float range = 100f;                      // 槍可以射擊的距離

    float timer;                                    // 觸發的計時器
    Ray shootRay;                                   // 槍射線向前
    RaycastHit shootHit;                            // 射線命中以獲取有關命中內容的信息
    int shootableMask;                              // 使射線投射僅擊中物體
    ParticleSystem gunParticles;                    // 粒子系統
    LineRenderer gunLine;                           // 引用線渲染器
    Light gunLight;                                 // 燈光組件
    float effectsDisplayTime = 0.2f;                // 效果將顯示在 子彈之間 的時間比例

    void Awake()
    {
        //可射擊Layer(Shootable)
        shootableMask = LayerMask.GetMask("Shootable");

        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
    }

    void Update()
    {
        // 時間添加到計時器。
        timer += Time.deltaTime;

        // 如果計時器已超過“子彈之間”的時間比例，則應顯示效果
        if (timer >= timeBetweenBullets * effectsDisplayTime)
        {
            //禁用射擊效果
            DisableEffects();
        }
    }

    //按鈕=射擊
    public void ButtonShoot()
    {
        Shoot();
    }
    //禁用效果
    public void DisableEffects()
    {
        // 禁用線條渲染器和燈光
        gunLine.enabled = false;
        gunLight.enabled = false;
    }

    void Shoot()
    {
        timer = 0f;

        // 啟用光源
        gunLight.enabled = true;

        // 如果粒子停止播放，則停止播放，然後啟動粒子。
        gunParticles.Stop();
        gunParticles.Play();

        // 啟用線條渲染器，並將其第一個位置設置為槍的末端。
        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        // 設置射線，使其從槍的末端開始並指向槍管。
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        // 對可射擊的遊戲對象進行光線投射，如果碰到東西，則進行光線投射
        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask))
        {
            // 嘗試在遊戲對象命中上找到“MosterHealth”腳本。
            MosterHealth mosterHealth = shootHit.collider.GetComponent<MosterHealth>();

            //如果存在MosterHealth
            if (mosterHealth != null)
            {
                //敵人應該受到傷害
                mosterHealth.TakeDamage(damagePerShot, shootHit.point);
            }

            // 將線條渲染器的第二個位置設置為射線投射命中的點
            gunLine.SetPosition(1, shootHit.point);
        }
        // 如果射線投射沒有在可射擊擊中任何東西
        else
        {
            // 將線條渲染器的第二位置設置為槍支射程的最大範圍
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
