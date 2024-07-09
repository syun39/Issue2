using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnswer : MonoBehaviour
{
    [SerializeField] protected int _hp;
    public int HP => _hp;

    public void Damage()
    {
        Debug.Log($"{gameObject.name}�Ƀ_���[�W");
        _hp--;
        if (_hp <= 0)
        {
            _hp = 0;
        }
    }
}
