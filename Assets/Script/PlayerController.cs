using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Tooltip("�uBullet�v�Ƃ������O�̃v���n�u���A�^�b�`���ĉ�����")]
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Vector2 _colliderSize = new Vector2(1, 1);
    [SerializeField] private float _speed = 1f; //�ړ��̑���
    [SerializeField] private float _jumpPower = 1f; //�W�����v��
    [SerializeField] private float _gravity = 9.8f; // �d��
    [SerializeField] public float _width = 1.0f; //��
    [SerializeField] public float _height = 1.0f; //����
    [SerializeField] private int _life = 5; //���C�t

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
            if (transform.position.y <= -3.4)
            {
                _isJumping = false;
                _jumpSpeed = 0;
            }
        }
    }

    /// <summary>
    /// �G�̒e�ɓ��������烉�C�t������
    /// </summary>
    public void PlayerDamage()
    {
        _life--;
        Debug.Log(_life);

        if (_life == 0) Debug.Log("GAME OVER!");
    }
}
