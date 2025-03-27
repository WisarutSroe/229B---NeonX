using UnityEngine;

public class AutoShoot : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab ของกระสุน
    public Transform firePoint; // ตำแหน่งที่ยิงกระสุนออกไป
    public float fireRate = 0.5f; // ความถี่ในการยิง (วินาทีต่อลูก)
    public float bulletSpeed = 1000f; // ความเร็วของกระสุน

    void Start()
    {
        InvokeRepeating("Shoot", 0f, fireRate); // เรียกฟังก์ชัน Shoot อัตโนมัติทุก fireRate วินาที
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning("bulletPrefab หรือ firePoint ไม่ถูกตั้งค่าใน Inspector!");
            return;
        }

        Debug.Log("Shooting!"); // ตรวจสอบว่าฟังก์ชันถูกเรียก

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.velocity = firePoint.forward * bulletSpeed;
        }
        else
        {
            Debug.LogWarning("กระสุนไม่มี Rigidbody! โปรดเพิ่ม Rigidbody ให้ Prefab ของกระสุน");
        }
    }
}
