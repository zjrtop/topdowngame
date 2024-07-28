using UnityEngine;

public class FloatEffect : MonoBehaviour
{
    public float floatStrength = 0.1f; // 浮动强度
    public float floatSpeed = 3f; // 浮动速度
    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // 上下浮动
        transform.position = initialPosition + new Vector3(0.0f, Mathf.Sin(Time.time * floatSpeed) * floatStrength, 0.0f);
    }
}
