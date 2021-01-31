
using UnityEngine;
using UnityEngine.Audio; //引用 音源管理 API

public class SoundManager : MonoBehaviour
{
    public AudioMixer mixer;

    public void SoundBGM(float v)
    {
        //音源管理.設定浮點數(名稱 , 值)
        mixer.SetFloat("SoundBGM", v);
    }

    public void SoundSFX(float v)
    {
        mixer.SetFloat("SoundSFX", v);
    }
}
