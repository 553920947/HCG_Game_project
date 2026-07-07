using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    private int _speedForward = 10; // 前进速度
    private int _speedSide = 5; // 侧向速度

    void Start()
    {
        // 新增这一行：自动获取当前物体身上的Rigidbody组件
        _rb = GetComponent<Rigidbody>();
        // 防御校验：防止物体没加Rigidbody时再次报错
        if (_rb == null)
        {
            Debug.LogError("Player物体缺少Rigidbody组件，请添加！", gameObject);
        }
    }

    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speedForward * Time.fixedDeltaTime); // 向前移动，速度为_speedForward * Time.fixedDeltaTime
        if (Input.GetKey(KeyCode.D)) // 按下D键时，向右移动
        {
            GoRight();
        }
        if (Input.GetKey(KeyCode.A))
        {
            GoLeft();
        }
    }

    private void GoLeft() // 向左移动
    {
        transform.Translate(Vector3.left * _speedSide * Time.fixedDeltaTime); // 向左移动，速度为_speedForward * Time.fixedDeltaTime
    }
    private void GoRight()
    {
        transform.Translate(Vector3.right * _speedSide * Time.fixedDeltaTime); // 向右移动，速度为_speedForward * Time.fixedDeltaTime
    }

    private void OnTriggerEnter(Collider other)
    {
        Gate_Result number = other.GetComponent<Gate_Result>();
        Debug.Log(number.NumberOfPlayers); // 打印碰撞物体的Number属性
    }
}