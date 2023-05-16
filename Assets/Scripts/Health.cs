using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _health = 100f;
    private float _arrmor;
    private bool _death;

    public bool Death
    {
        get { return _death; }
        //set { _death = value; }
    }

    private void Start()
    {
        AddArrmor();
    }

    public float _Health
    {
        get { return _health; }
    }

    public void AddArrmor()
    {
        _health += _arrmor;
    }

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if (_health <= 0 && !_death)
        {
            _death = true;
        }
    }
}
