using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

// 可序列化类，允许在Unity Inspector中显示和编辑
[System.Serializable]
public class AudioType
{
    // 在Inspector中隐藏Source属性，因为它在运行时动态创建
    [HideInInspector]
    public AudioSource Source;  // 储存音频源

    // 音频剪辑，表示实际的音频文件
    public AudioClip Clip; 

    // 音频混合组，用于音频输出的混合
    public AudioMixerGroup Group;

    // 音频的名称，用于识别和控制音频
    public string Name;

    // 音量，范围从0到1
    [Range(0f, 1f)]
    public float Volume;

    // 音高，范围从0.1到5
    [Range(0.1f, 5f)]
    public float Pitch;

    // 是否循环播放
    public bool Loop;
}
