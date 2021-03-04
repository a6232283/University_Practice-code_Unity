using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtck : MonoBehaviour
{
    public int damagePerShot = 100;//自己打                  // 造成的傷害
    public float range = 500f;                      // 攻擊可以射擊的距離

    Ray AtkRay;                                   // 攻擊射線向前
    RaycastHit shootHit;                            // 射線命中以獲取有關命中內容的信息
    int shootableMask;                              // 使射線投射僅擊中物體
    ParticleSystem Particles;                    // 粒子系統

    AudioSource Audio;//自己打                            //music
    void Awake()
    {
        //可射擊Layer(Shootable)
        shootableMask = LayerMask.GetMask("Shootable");

        Particles = GetComponent<ParticleSystem>();

        Particles.Stop();

        Audio = GetComponent<AudioSource>();
    }

    void Update()
    {
    }

    //按鈕=射擊//自己打 
    public void ButtonShoot()
    {
        Shoot();
    }
    

    void Shoot()
    {
       StartCoroutine(Main.Instance.Web.Game1("玩家按下攻擊", SystemInfo.deviceModel));

        //music play//自己打 
        Audio.Play();

        // 如果粒子停止播放，則停止播放，然後啟動粒子。
        Particles.Stop();
        Particles.Play();


        // 設置射線，使其從攻擊的末端開始並指向攻擊。
        AtkRay.origin = transform.position;
        AtkRay.direction = transform.forward;

        // 對可射擊的遊戲對象進行光線投射，如果碰到東西，則進行光線投射
        if (Physics.Raycast(AtkRay, out shootHit, range, shootableMask))
        {
            // 嘗試在遊戲對象找到“MosterHealth”腳本。
            MosterHealth mosterHealth = shootHit.collider.GetComponent<MosterHealth>();

            //如果存在MosterHealth
            if (mosterHealth != null)
            {
                //敵人應該受到傷害
                mosterHealth.TakeDamage(damagePerShot, shootHit.point);
            }

        }
    }
}
