using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed = 10f; //�e�̃X�s�[�h

    void Update()
    {
        //�E�ֈړ�
        transform.Translate(Vector2.right * _speed * Time.deltaTime);

        //��ʊO�ɏo�������
        /*if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }*/
    }
}