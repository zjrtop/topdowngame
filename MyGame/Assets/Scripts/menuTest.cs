using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menuTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //开始游戏
    public void StartGame(){
        // 加载场景下标
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }



    //继续游戏

    //游戏设置

    //退出游戏


}
