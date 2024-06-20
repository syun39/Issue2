using UnityEngine;

public class EnemyBullet : Bullet
{

    void Update()
    {
        //左へ
        transform.Translate(Vector2.left * _bulletSpeed * Time.deltaTime);

        //画面外に出たら消す
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
