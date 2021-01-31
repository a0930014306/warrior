
using UnityEngine;

/// <summary>
/// 認識 API 靜態 Static
/// </summary>
public class APIStatic : MonoBehaviour
{
    private int count;

    private void Start()
    {
        #region 靜態屬性
        //屬性
        //取得 靜態屬性
        //語法:
        //類別名稱.靜態屬性

        print("隨機值:" + Random.value);
        print("拍:" + Mathf.PI);

        //設定 靜態屬性
        //語法:
        //類別名稱.靜態屬性 = 值;

        Cursor.visible = false;

        //如果有 Read Only 不能設定 - 唯讀
        //Time.deltaTime = 0.5f; 錯誤

        Time.timeScale = 2;
        #endregion

        #region 靜態方法
        //使用 靜態方法
        //語法
        //類別名稱.靜態方法(對應引數)

        print("隨機值介於 100 - 500 :" + Random.Range(100 , 500));

        int number = Mathf.Abs(-80);
        print("去掉絕對值的整數:" + number);

        #endregion

        #region 練習
        count = Camera.allCamerasCount;
        print("攝影機數量:" + count);
        print("2D重力大小:" + Physics2D.gravity);

        Physics2D.gravity = new Vector2(0, -20);

        print("對9.999去小數點:" + Mathf.Floor(9.999f));
        Application.OpenURL("https://www.appedu.com.tw//");
        print("取得兩點間的距離:" + Vector3.Distance(new Vector3(1, 1, 1), (new Vector3(22, 22, 22))));

        #endregion
    }

    
    private void Update()
    {
        #region 練習2
        print("是否輸入任意鍵:" + Input.anyKeyDown);
        print("遊戲經過時間:" + Time.time);



        print("是否按下空白鍵:" + (Input.GetKeyDown(KeyCode.Space)));
       
    }
    #endregion
    }
