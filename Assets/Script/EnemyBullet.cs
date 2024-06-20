using UnityEngine;

public class EnemyBullet : Bullet
{

    void Update()
    {
        //¶‚Ö
        transform.Translate(Vector2.left * _bulletSpeed * Time.deltaTime);

        //‰æ–ÊŠO‚Éo‚½‚çÁ‚·
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
