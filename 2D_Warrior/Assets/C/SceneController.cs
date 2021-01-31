using UnityEngine.SceneManagement; //引用 場景管理 API
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [Header("音效來源")]
    public AudioSource aud;
    [Header("按鈕音效")]
    public AudioClip soundtrack;

    //1.方法要讓按鈕呼叫必須設為公開 public

    

    private void DelayStartgame()
    {

        //2.必須將場景放在 File > BuildSettings ...
        //場景管理器.載入場景(場景名稱);
        SceneManager.LoadScene("地板牆壁");
    }

    private void DelayBackToMenu()
    {
        SceneManager.LoadScene("選單");
    }

    private void DelayQuitGame()
    {

        //2.必須將場景放在 File > BuildSettings ...
        //場景管理器.載入場景(場景名稱);
        Application.Quit();
    }

    /// <summary>
    /// 開始遊戲
    /// </summary>
    public void Startgame()
    {
        //音效來源,播放一次(音效, 音量)
        aud.PlayOneShot(soundtrack);
        Time.timeScale = 1;
        Invoke("DelayStartgame", 1.5f);
    }


    /// <summary>
    /// 返回選單
    /// </summary>
    public void BackToMenu()
    {
        aud.PlayOneShot(soundtrack);
        Time.timeScale = 1;
        Invoke("DelayBackToMenu", 1.5f);
    }


    /// <summary>
    /// 離開遊戲
    /// </summary>
    public void QuitGame()
    {
        aud.PlayOneShot(soundtrack);
        //應用程式.離開
        Invoke("DelayQuitGame", 1.5f);
    }



}
