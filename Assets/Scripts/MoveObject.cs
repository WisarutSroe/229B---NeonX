using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 3.0f;
    public float distance = 5.0f;
    private Vector3 startPosition;
    private Rigidbody rb;

    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>(); // ดึง Rigidbody ของ Object
    }

    void FixedUpdate()
    {
        float movement = Mathf.PingPong(Time.time * speed, distance * 3) - distance;
        Vector3 newPosition = startPosition + new Vector3(movement, 0, 0);

        rb.MovePosition(newPosition); // ใช้ MovePosition เพื่อให้ Object เคลื่อนที่ตามฟิสิกส์
    }
}
