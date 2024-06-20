using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("�uBullet�v�Ƃ������O�̃v���n�u���A�^�b�`���ĉ�����")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private float _speed = 1f; //�ړ��̑���
    [SerializeField] private float _jumpPower = 1f; //�W�����v��
    [SerializeField] private float _gravity = 9.8f; // �d��

    private bool _isJumping = false;
    private float _jumpSpeed = 0f; //�W�����v�̑���

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        //�ړ�
        var horizontal = new Vector3(x* _speed * Time.deltaTime,0,0);
        transform.position += horizontal;

        //W�������ꂽ��e�𐶐�
        if (Input.GetKeyDown(KeyCode.W))
        {
            Instantiate(_bulletPrefab, transform.position, Quaternion.identity);
        }

        // �W�����v
        if (Input.GetKeyDown(KeyCode.Space) && _isJumping == false)
        {
            _isJumping = true;
            _jumpSpeed = _jumpPower;
        }

        // �W�����v��
        if (_isJumping)
        {
            _jumpSpeed -= _gravity * Time.deltaTime; //�d�͂�^����
            transform.Translate(new Vector2(0, _jumpSpeed) * Time.deltaTime);


            // �n�ʂɒ������烊�Z�b�g
            if (transform.position.y <= -4)
            {
                _isJumping = false;
                _jumpSpeed = 0;
            }
        }
    }
}
