using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Tooltip("�uEBullet�v�Ƃ������O�̃v���n�u���A�^�b�`���ĉ�����")]
    [SerializeField] GameObject _enemyBulletPrefab;
    [SerializeField] float _shootDistance = 5f; //���̋����ȉ��Ō��Ă�
    [SerializeField] int _Interval = 1; //���ˊԊu
    [Tooltip("�uPlayer�v���A�^�b�`���ĉ�����")]
    [SerializeField] Transform _player; //�v���C���[�̍��W
    

    private float _currentTime; //�o�߂����b��
    private bool _isShoot = false; //���ˍς݂��ǂ���

    void Update()
    {
        //�v���C���[�ƓG�̋���
        float distance = Vector2.Distance(transform.position, _player.position);

        if (distance < _shootDistance)
        {
            if (_isShoot == false)
            {
                Instantiate(_enemyBulletPrefab, transform.position, Quaternion.identity);
                _isShoot = true;
                _currentTime = 0; //�o�߂������Ԃ�0�ɖ߂�
            }

            else
            {
                //_currentTime += Time.time; �����ƈ�x�ɑ����̒e����������Ē����_�̂悤�ɂȂ�̂͂Ȃ����H
                _currentTime += Time.deltaTime;

                if (_Interval < _currentTime)
                {
                    Instantiate(_enemyBulletPrefab, transform.position, Quaternion.identity);
                    _currentTime = 0; //�o�߂������Ԃ�0�ɖ߂�
                }
            }
        }
    }
}
