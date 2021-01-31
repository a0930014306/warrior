
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class player : MonoBehaviour
{
    #region 角色欄位
    [Header("移動速度"), Range(0, 1000)]
    public float movespeed = 15;
    [Header("跳躍高度"), Range(0, 3000)]
    public int jump = 850;
    [Header("是否在地板上")]
    public bool ground = true;
    [Header("子彈")]
    public GameObject bullet;
    [Header("子彈生成點")]
    public Transform bulletborn;
    [Header("子彈速度"), Range(0, 5000)]
    public int bulletspeed = 800;
    [Header("子彈傷害"), Range(0, 5000)]
    public int bulletdamage = 50;
    [Header("開槍音效")]
    public AudioClip shootaud;
    [Header("血量"), Range(0, 200)]
    public float hp = 100;
    [Header("地面判定位移")]
    public Vector3 groundmove;
    [Header("地面判定半徑")]
    public float radius = 0.5f;
    [Header("鑰匙音效")]
    public AudioClip keysound;
    [Header("血量文字")]
    public Text texthp;
    [Header("血量圖片")]
    public Image imghp;
    [Header("結束畫面")]
    public GameObject gamefinish;

    public AudioSource aud;
    private Rigidbody2D rig;
    private Animator ani;
    private float hpMax;
    private SpriteRenderer spr;

    #endregion

    //取得玩家軸向的值
    public float h;
    

    private void Start()
    {
        //GetComponent<泛型>()
        //泛型:泛指所有類型
        //GetComponent<Animator>()
        //GetComponent<AudioSource>()

        //剛體欄位 = 取得原件<剛體>();
        rig = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        hpMax = hp;


    }
    public void Update()
    {
        GetHorizontal();
        Move();
        Jump();
        Shoot();
        
    }

    //在 unity 繪製圖示
    private void OnDrawGizmos()
    {
        //圖示.顏色 = 顏色
        Gizmos.color = new Color(1, 0, 0, 0.35f);
        //圖示.繪製球體(中心點,半徑)
        Gizmos.DrawSphere(transform.position + groundmove, radius);
    }


    /// <summary>
    /// 觸發事件:Enter進入時執行一次
    /// </summary>
    /// <param name="collision">碰到的物件資訊</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "鑰匙") 
        {
            Destroy(collision.gameObject);
            aud.PlayOneShot(keysound, Random.Range(1.2f, 1.5f));
        }
        
    }
    /// <summary>
    /// 取得水平軸向
    /// </summary>
    public void GetHorizontal()
    {
        //浮點數 = 輸入.取得軸向("水平")
        h = Input.GetAxis("Horizontal");
    }


    private void Move()
    {

        //剛體.加速度 = 二維(水平 * 速度, 剛體原本的加速度 Y);
        rig.velocity = new Vector2(h * movespeed, rig.velocity.y);

        //如果 玩家 按下 D 或 右鍵 就執行(內容)
        if (Input.GetKeyDown(KeyCode.D) || (Input.GetKeyDown(KeyCode.RightArrow)))
        {
            //transform 指的是與此腳本同一層的 元件
            //Rotation 角度在程式是 localEulerAngles
            transform.localEulerAngles = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.A) || (Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            transform.localEulerAngles = new Vector3(0, 180, 0);

        }

        ani.SetBool("跑步開關", h != 0);
    }



    private void Jump()
    {
        //如果 在地板上 且 按下空白鍵 才可以跳躍
        if (ground && Input.GetKeyDown(KeyCode.Space))
        {
            //剛體.添加推力(二維向量);
            rig.AddForce(new Vector2(0, jump));

        }

        //碰撞物件 = 2D 物理.覆蓋圓形(中心點,半徑,圖層) 有layerMask(圖層編號) 以 1<<圖層 表示
        Collider2D hit = Physics2D.OverlapCircle(transform.position + groundmove, radius, 1 << 8);

        //如果 在地面上 是否在地面上 = 是
        if (hit)
        {
            ground = true;
        }
        //否則 是否在地面上 = 否
        else
        {
            ground = false;
        }



    }

    private void Shoot()
    {    
        //按下滑鼠左鍵(手機為觸控)
        if (Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            //音效來源.撥放一次音效(音效片段,音量)
            aud.PlayOneShot(shootaud,Random.Range(1.2F,1.5F));
            //區域變數 名稱 = 生成(物件,座標,角度)
            GameObject temp = Instantiate(bullet, bulletborn.position, bulletborn.rotation);

            temp.GetComponent<Rigidbody2D>().AddForce(bulletborn.right * bulletspeed + bulletborn.up * 150);

            //暫存子彈.添加元件<子彈>().攻擊力 = 子彈傷害
            temp.AddComponent<Bullet>().attack = bulletdamage;
        }

        
    }

    public void Hurt(float damage)
    {
        hp -= damage;                   //遞減
        texthp.text = hp.ToString();    //血量文字.文字內容 = 血量.轉字串()
        imghp.fillAmount = hp / hpMax;  //血量圖片.填滿長度 = 目前血量 / 最大血量;
        StartCoroutine(HurtEffect());

        if (hp <= 0) Dead();
    }

    private IEnumerator HurtEffect()
    {
        float interval = 0.05f;

        for (int i = 0; i < 5; i++)
        {

        Color red = new Color(1, 0.1f, 0.1f);
        spr.color = red;
        yield return new WaitForSeconds(0.1f);
        spr.color = Color.white;
        yield return new WaitForSeconds(0.1f);

        }

    }

    private void Dead()
    {
        hp = 0;
        texthp.text = 0.ToString();
        ani.SetBool("死亡開關", true);
        rig.Sleep();
        enabled = false;

        gamefinish.SetActive(true);
    }
}
