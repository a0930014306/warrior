
using UnityEngine;
using UnityEngine.UI;     //引用 介面
using System.Collections; //引用 系統.集合 API - 協同程序需要
using UnityEngine.Events; //引用 事件
[RequireComponent(typeof(Rigidbody2D), typeof(AudioSource), typeof(CapsuleCollider2D))]
public class enemy : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 7;
    [Header("攻擊範圍"), Range(0, 100)]
    public float atkrange = 10;
    [Header("攻擊冷卻"), Range(0, 10)]
    public float atkcd = 2;
    [Header("傷害延遲時間"), Range(0, 10)]
    public float atkdelay = 0.7f;
    [Header("攻擊力"), Range(0, 1000)]
    public float power = 10;
    [Header("血量"), Range(0, 5000)]
    public float hp = 2500;
    [Header("血量文字")]
    public Text texthp;
    [Header("血量圖片")]
    public Image imghp;
    [Header("攻擊範圍位移")]
    public Vector3 offsetatk;
    [Header("攻擊範圍大小")]
    public Vector3 sizeatk;
    [Header("事件")]
    public UnityEvent onDead;
    




    private Animator ani;
    private AudioSource aud;
    private Rigidbody2D rig;
    public float hpMax;
    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;
    private player player;
    private CameraControl2D cam;
    private bool issecond;
    private ParticleSystem pssecond;

    private void Start()
    {
        ani = GetComponent<Animator>();
        aud = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        hpMax = hp;
        //透過類型尋找物件<物件>() - 不能有重複物件
        player = FindObjectOfType<player>();
        cam = FindObjectOfType<CameraControl2D>();
        pssecond = GameObject.Find("骷髏二階段").GetComponent<ParticleSystem>();
    }

    private void Update()
    { 
        //如果 死亡開關 已勾選 就跳出
        if(ani.GetBool("死亡開關")) return; 
        Move();
    }

    //僅在編輯器內顯示,發布後看不見
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position + transform.right * offsetatk.x +transform.up * offsetatk.y ,sizeatk);

        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawSphere(transform.position , atkrange);
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收傷害值</param>
    public void Damage(float damage) 
    {
        hp -= damage;                    //遞減
        ani.SetTrigger("受傷觸發");      //受傷動畫
        texthp.text = hp.ToString();    //血量文字.文字內容 = 血量.轉字串()
        imghp.fillAmount = hp / hpMax;  //血量圖片.填滿長度 = 目前血量 / 最大血量;

        if (hp <= 0) Dead();

        if (hp <= hpMax * 0.8)
        {
            issecond = true;
            atkrange = 25;
        }
    }

    private void Dead()
    {
        onDead.Invoke();

        hp = 0;
        texthp.text = 0.ToString(); 
        ani.SetBool("死亡開關",true);

        GetComponent<CapsuleCollider2D>().enabled = false;
        //剛體睡著
        rig.Sleep();
        //剛體.約束 = 剛體約束.凍結全部;
        rig.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void Move()
    {
        /** 判斷式寫法
        if (transform.position.x > player.transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        */

        //三元運算子 - 布林值 ? 結果1 : 結果2

        //y = x是否大於玩家x ? 是 y = 180 : 否 y = 0
        float y = transform.position.x > player.transform.position.x ? 180 : 0;
        transform.eulerAngles = new Vector3(0, y, 0);


        float dis = Vector2.Distance(transform.position ,player.transform.position);

        if (dis > atkrange)
        {
            //剛體.移動座標(座標 + 前方 * 一禎時間 *速度)
            rig.MovePosition(transform.position + transform.right * Time.deltaTime * speed);

        }
        else
        {
            Attack();

        }

        //動畫.設定布林值("走路開關" , 剛體.速度.值(vector轉為布林值) > 0)
        ani.SetBool("走路開關", rig.velocity.magnitude > 0);

        //取得動畫控制器狀態資訊 資訊 = 動畫.取得正確動畫控制器狀態資訊(圖層);
        AnimatorStateInfo info = ani.GetCurrentAnimatorStateInfo(0);
        //如果 動畫是 骷髏攻擊 就 停止
        if (info.IsName("骷髏攻擊")) return;

    }

    private void Attack()
    {
        rig.velocity = Vector3.zero;

        if (timer < atkcd)
        {
            timer += Time.deltaTime;

        }
        else
        {
            ani.SetTrigger("攻擊觸發");
            timer = 0;
            StartCoroutine(DelayDamage());
        }

        if (hp <= hpMax * 0.8f) atkrange = 10;

    }

    //  IEnumerator 允許傳回時間
    /// <summary>
    /// 延遲傳送傷害
    /// </summary>
    /// <returns></returns>
    private IEnumerator DelayDamage()
    {

        //等待延遲時間
        yield return new WaitForSeconds(atkdelay);
        //碰撞物件 = 2D.盒型覆蓋區域(中心點,尺寸,角度,圖層)
        Collider2D hit = Physics2D.OverlapBox(transform.position + transform.right * offsetatk.x + transform.up * offsetatk.y, sizeatk, 0, 1 << 9);
        //如果(攻擊) 玩家.傷害(攻擊力)
        if (hit) player.Hurt(power);
        StartCoroutine(cam.Shake());

        if (issecond) pssecond.Play();
    }
    

}
