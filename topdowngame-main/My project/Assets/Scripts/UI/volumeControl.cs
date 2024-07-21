using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class volumeControl : MonoBehaviour
{
    // 需要控制的声音是什么
    private AudioSource menuAudio;
    // 获取的滑动条
    private Slider audioSlider;
    // Start is called before the first frame update
    void Start()
    {
        menuAudio = GameObject.FindGameObjectWithTag("mainMenu").transform.GetComponent<AudioSource>();
        audioSlider =  GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        VolumeControl();
    }

    // 控制声音音效
    public void VolumeControl(){
        // 控制声音
        menuAudio.volume = audioSlider.value;
        // 同时控制多个声音
        // 获取到需要控制的声音，把声音的音量和滑动条挂钩就行了
    }

    // 关闭游戏设置界面
    
}
