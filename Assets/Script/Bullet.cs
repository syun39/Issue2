using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f; //�e�̃X�s�[�h
    [SerializeField] float _width = 0.6f; //��
    [SerializeField] float _height = 0.3f; //����

    //�e�̒��S
    private Vector2 _bulletCenter;

    void Update()
    {
        //�E��
        transform.Translate(_bulletSpeed * Time.deltaTime * Vector2.right);

        //��ʊO�ɏo�������
        if (transform.position.x > 10)
        {
            Destroy(gameObject);
        }

        //���S���X�V
        _bulletCenter = new Vector2(transform.position.x, transform.position.y);

        //�S�Ă̓G��T��
        var enemies = FindObjectsOfType<Enemy>();

        //�S�Ă̓G�ƏՓ˔���
        foreach (var enemy in enemies)
        {
            if (CheckCollision(enemy) == true) //�Փ˂�����
            {
                //Debug.Log("Enemy Hit!");
                enemy.EnemyDamage();
                Destroy(gameObject);
                break;
            }
        }
    }

    /// <summary>
    /// �G�Ƃ̏Փ˔���
    /// </summary>
    /// <param name="enemy"></param>
    /// <returns></returns>
    private bool CheckCollision(Enemy enemy)
    {
        float enemyWidth = enemy._width;
        float enemyHeight = enemy._height;

        //�G�̒��S
        Vector2 enemyCenter = new(enemy.transform.position.x, enemy.transform.position.y);

        //x���̋�����x���̕��̔����̘a������������
        //y���̋�����y���̍����̔����̘a������������
        if (Mathf.Abs(_bulletCenter.x - enemyCenter.x) < (_width + enemyWidth) / 2 &&
            Mathf.Abs(_bulletCenter.y - enemyCenter.y) < (_height + enemyHeight) / 2)
        {
            return true; //�Փ�
        }
        return false; //�Փ˂��ĂȂ�
    }
}