using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    // 静态实例，用于实现单例模式
    public static AudioManager instance;

    // 存储所有音频类型的数组
    public AudioType[] AudioTypes;

    // Awake方法在脚本实例化时调用
    private void Awake()
    {
        // 检查是否已经存在一个实例
        if (instance == null)
        {
            instance = this; // 如果不存在，将当前实例设为唯一实例
        }
        else
        {
            Destroy(gameObject); // 如果已经存在实例，销毁当前对象
            return;
        }

        // 确保在场景切换时不会销毁此对象
        DontDestroyOnLoad(gameObject);
    }

    // Start方法在脚本启用时调用
    private void Start()
    {
        // 遍历所有音频类型
        foreach (AudioType type in AudioTypes)
        {
            // 为每个音频类型添加一个AudioSource组件
            type.Source = gameObject.AddComponent<AudioSource>();

            // 设置AudioSource组件的属性
            type.Source.clip = type.Clip;
            type.Source.name = type.Name;
            type.Source.volume = type.Volume;
            type.Source.pitch = type.Pitch;
            type.Source.loop = type.Loop;

            // 如果音频类型有指定的音频混合组，设置该组
            if (type.Group != null)
            {
                type.Source.outputAudioMixerGroup = type.Group;
            }
        }
    }

    // 播放指定名称的音频
    public void Play(string name)
    {
        // 遍历所有音频类型
        foreach (AudioType type in AudioTypes)
        {
            // 如果找到匹配的名称，播放音频
            if(type.Name == name)
            {
                type.Source.Play();
                return;
            }
        }
        // 如果没有找到匹配的音频，输出警告信息
        Debug.LogWarning("没有找到" + name + "音频！");
    }

    // 暂停指定名称的音频
    public void Pause(string name)
    {
        // 遍历所有音频类型
        foreach (AudioType type in AudioTypes)
        {
            // 如果找到匹配的名称，暂停音频
            if (type.Name == name)
            {
                type.Source.Pause();
                return;
            }
        }
        // 如果没有找到匹配的音频，输出警告信息
        Debug.LogWarning("没有找到" + name + "音频！");
    }

    // 停止指定名称的音频
    public void Stop(string name)
    {
        // 遍历所有音频类型
        foreach (AudioType type in AudioTypes)
        {
            // 如果找到匹配的名称，停止音频
            if (type.Name == name)
            {
                type.Source.Stop();
                return;
            }
        }
        // 如果没有找到匹配的音频，输出警告信息
        Debug.LogWarning("没有找到" + name + "音频！");
    }
}
