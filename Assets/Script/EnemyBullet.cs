using UnityEngine;

public class EnemyBullet : Bullet
{

    void Update()
    {
        //����
        transform.Translate(Vector2.left * _bulletSpeed * Time.deltaTime);

        //��ʊO�ɏo�������
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }
    }
}
