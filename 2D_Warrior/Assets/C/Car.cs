﻿using UnityEngine;

public class Car : MonoBehaviour
{
    #region 練習欄位
    //單行註解:不會被程式讀取
    //欄位語法;
    //修飾詞 類型 名稱 (指定 值);

    //四大種類
    //整數 int
    //浮點數 float
    //字串 string
    //布林值 bool

    //修飾詞
    //私人:不會顯示(預設) private+
    //公開:會顯示 public    

    //指定符號: = 

    //欄位屬性
    //語法
    //[屬性名稱("字串或對應的值")]
    //標題
    //提示
    //範圍
    [Header("這是汽車的高度"),Range(1,10)]
    public int height = 5;
    [Tooltip("這是汽車的重量,單位是噸"),Range(2.5f,10.5f)]
    //Tooltip 游標放置在字上面才會顯示
    public float weight = 5.5F;
    [Header("這是汽車的品牌")]
    public string Brand = "BMW";
    [Header("這是汽車是否有天窗")]
    public bool hasWindow = true;
    //是 : true
    //否 : false

    //其他類型
    //顏色

    public Color mycolor;
    public Color red = Color.red;
    public Color blue = Color.blue;
    public Color mycolor2 =new Color(0.5f, 0.3f, 0.1f);
    public Color mycolor3 = new Color(0, 0.5f, 0.3f, 0.5f);
    //紅 ,綠 ,藍, 透明度

    //座標
    //向量維度(2 - 4)

    public Vector2 V2Azero = Vector2.zero;
    public Vector2 V2Bone = Vector2.one;
    public Vector2 V2A = new Vector2(1.5f, 2.5f);
    public Vector3 V3A = new Vector3(1, 1, 1);
    public Vector4 V4A = new Vector4(1, 1, 1, 1);

    //圖片與音效

    public Sprite picture;
    public AudioClip sound;

    //遊戲物件與元件
    //遊戲物件:儲存階層面板內的物件與預製物

    public GameObject objA;
    public GameObject objB;

    //元件:儲存屬性面板裡可摺疊的元件

    public Transform tra;
    public Camera cam;

    #endregion

    #region 練習方法
    //欄位語法
    //修飾詞 類型 名稱(指定 值)

    //方法語法
    //修飾詞 回傳值 名稱(){}

    //void 無傳回:呼叫此方法後不會傳回任何資料

    private void Test()
    {
        //輸出 方法
        print("你好!");
    }

    //傳回類型:int
    //必須傳回 整數資料
    private int Ten()
    {
        return 10;
    }

    private float OnePointFive()
    {
        return 1.5f;
    }

    private string Name()
    {
        return "Goblin";
    }

    //擴充維護性
    /// <summary>
    /// 開車方法
    /// </summary>
    /// <param name="direction">方向</param>
    /// <param name="sound">音效</param>
    /// <param name="speed">速度</param>
    private void Drive(string direction,string sound,int speed)
    {
        print("開車方向:" + direction);
        print("開車音效:" + sound);
        print("開車速度:" + speed);
    }

    /// <summary>
    /// 開啟雨刷
    /// </summary>
    /// <param name="sound">雨刷音效</param>
    /// <param name="speed">雨刷速度</param>
    /// <param name="count">雨刷數量</param>
    /// 有預設值的參數要放在最後面
    private void Openbrush(string sound,int count = 2,int speed = 50)
    {
        print("開雨刷");
        print("雨刷的音效:" + sound);
        print("雨刷的速度:" + speed);
        print("雨刷的數量:" + count);

    }

    //名稱藍色:事件
    //在特定時間點會執行的方法
    //開始事件:遊戲開始時執行一次

    private void Start()
    {
        //使用欄位
        //取得 Get
        print("品牌:" + Brand);
        print("高度:" + height);
        //設定 Set
        hasWindow = false;
        weight = 5.5f;

        //呼叫方法
        //方法名稱();
        Test();

        //傳回方法使用方式
        //1.直接當作傳回類型資料使用
        print("傳回的整數:" + Ten());
        print("傳回的浮點數:" + OnePointFive());

        //2.儲存在區域變數內
        //區域變數:在事件或方法內可使用的欄位
        //僅限於此括號內可使用

        string myNAME = Name();

        print(myNAME);
        Drive("後面","噗噗噗",100);
        Drive("前面","噗噗噗",50);
        Drive("後面","咻咻咻",999);

        Openbrush("刷刷");
        //指定預設值參數 參數名稱 : 值
        Openbrush("刷刷", speed : 500);

    }
    #endregion
}
