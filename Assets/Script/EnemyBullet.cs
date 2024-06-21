using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] float _bulletSpeed = 10f; //�e�̃X�s�[�h
    [SerializeField] private float _width = 0.5f; //��
    [SerializeField] private float _height = 0.5f; //����

    //�e�̒��S
    private Vector2 EnemyBulletCenter;

    void Update()
    {
        //����
        transform.Translate(Vector2.left * _bulletSpeed * Time.deltaTime);

        //��ʊO�ɏo�������
        if (transform.position.x < -10)
        {
            Destroy(gameObject);
        }

        // �e�̒��S���X�V
        EnemyBulletCenter = new Vector2(transform.position.x, transform.position.y);

        var player = FindObjectOfType<PlayerController>();

        if (CheckCollision(player) == true) //�Փ˂�����
        {
            //Debug.Log("Player hit");
            player.PlayerDamage();
            Destroy(gameObject); // �e������
        }
    }

    /// <summary>
    ///�v���C���[�Ƃ̏Փ˔���
    /// </summary>
    /// <param name="player"></param>
    /// <returns></returns>
    private bool CheckCollision(PlayerController player)
    {
        float playerWidth = player._width;
        float playerHeight = player._height;
        //�v���C���[�̒��S
        Vector2 playerCenter = new Vector2(player.transform.position.x, player.transform.position.y);

        //�e�ƃv���C���[�̒��S��x���W�̍��������̕��̔����̍��v��菬������
        //�e�ƃv���C���[�̒��S��y���W�̍��������̍����̔����̍��v��菬������
        if (Mathf.Abs(EnemyBulletCenter.x - playerCenter.x) < (_width + playerWidth) / 2 && 
            Mathf.Abs(EnemyBulletCenter.y - playerCenter.y) < (_height + playerHeight) / 2)
        {
            return true; //�Փ˂��Ă���
        }
        return false; //�Փ˂��Ă��Ȃ�
    }
}
