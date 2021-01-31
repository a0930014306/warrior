
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private player player;

    //呼喚方法
    private void Awake()
    {
        player = FindObjectOfType<player>();
    }

    /// <summary>
    /// 按設定暫停遊戲
    /// </summary>
    public void PauseGame()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }

    /// <summary>
    /// 關閉設定介面繼續遊戲
    /// </summary>
    public void ReStartGame()
    {
        Time.timeScale = 1;
        player.enabled = true;
    }
}
