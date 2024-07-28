using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float floatStrength = 0.1f; // 调整为较小的浮动强度
    public float floatSpeed = 6f; // 新增一个变量来控制浮动的速度
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.position = initialPosition + new Vector3(0.0f, Mathf.Sin(Time.time * floatSpeed) * floatStrength, 0.0f);
    }
}
