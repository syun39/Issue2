using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public float _bulletSpeed = 10f; //�e�̃X�s�[�h

    void Update()
    {
        //�E��
        transform.Translate(Vector2.right * _bulletSpeed * Time.deltaTime);

        //��ʊO�ɏo�������
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}