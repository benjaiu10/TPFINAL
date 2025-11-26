using UnityEngine;

public class SlowBullet : MonoBehaviour
{
    public float slowAmount = 2f;     // cuanto lo frena
    public float slowDuration = 2f;   // cuanto dura el efecto

    void OnCollisionEnter(Collision collision)
    {
        Enemy enemy = collision.collider.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.SlowDown(slowAmount, slowDuration);
        }
    }
}
