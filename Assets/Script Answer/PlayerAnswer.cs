using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnswer : CharacterAnswer
{
    [SerializeField] float _speed = 5.0f;
    [SerializeField] float _extinc = 0.3f;
    [SerializeField] float _gvScale = 0.3f;
    [SerializeField] float _scale = 10.0f;
    [SerializeField] float _jumpPow = 10.0f;
    float _jumpY = 0.0f;
    float _jtime = 0.0f;

    private void Start()
    {
        GameManagerAnswer.Instance.Register(this);
    }

    void Update()
    {
        if (_hp <= 0)
        {
            //�Q�[���I�[�o�[
            //return;
        }

        float v = Input.GetAxis("Horizontal");
        this.transform.position += new Vector3(v, 0, 0) * Time.deltaTime * _speed;

        if (_jumpY < 0.001f)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpY = _jumpPow; //����
                _jtime = 0.0f;
            }
        }
        else
        {
            /*
            _grav += Time.deltaTime;
            _jumpY *= 1.0f - Time.deltaTime * _extinc;
            float y = this.transform.position.y;
            y += (_jumpY - 9.81f * _grav) * Time.deltaTime * _scale;
            */
            _jtime += Time.deltaTime; //�o�ߎ���
            _jumpY *= 1.0f - Time.deltaTime * _extinc; //�͂̌���
            float y = this.transform.position.y;
            y = (_jumpY * _jtime - 9.81f * _jtime * _jtime * _gvScale) * _scale + -4.0f; //(��*����+�d�͉����x*�d�͂̋���) * �X�P�[��

            if (y < -4.0f)
            {
                y = -4;
                _jtime = 0;
                _jumpY = 0;
            }
            this.transform.position = new Vector3(this.transform.position.x, y, this.transform.position.z);
        }
    }
}