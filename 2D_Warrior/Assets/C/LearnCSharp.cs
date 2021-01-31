
using UnityEngine;

public class LearnCSharp : MonoBehaviour
{
    private int a = 10;
    private int b = 3;

    private void Start()
    {
        //比較運算子
        //傳回布林值
        print(a > b);
        print(a < b);
        print(a == b);
        print(a != b);

        print(a + b);
        print(a - b);
        print(a * b);
        print(a / b);

        //邏輯運算子
        //並且 &&
        //只要有一個F 結果為F

        print(true && true);
        print(true && false);
        print(false && true);
        print(false && false);

        //或者 ||
        //只要有一個T 結果為T
        print(true || true);
        print(true || false);
        print(false || true);
        print(false || false);

        //相反 !
        print("相反運算子:" + !true);
        print("相反運算子:" + !false);
    }

}
