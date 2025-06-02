using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public enum ON_DEFEAT_BEHAVIOUR {DISABLE = 0, DESTROY = 1, NONE = 2}

    [SerializeField] private int _currentHp = 10;
    [SerializeField] private int _maxHp = 10;
    [SerializeField] private bool _fullHpOnStart = true;
    [SerializeField] private ON_DEFEAT_BEHAVIOUR _onDefeatBehaviour = ON_DEFEAT_BEHAVIOUR.DISABLE;

    public int GetHp() => _currentHp;
    public int GetMaxHp() => _maxHp;

    public void SetHp(int hp)
    {
        hp = Mathf.Clamp(hp, 0, _maxHp);

        if (_currentHp != hp)
        {
            _currentHp = hp;

            if (_currentHp == 0)
            {
                Debug.Log($"Il GameObject {gameObject.name} è sceso a 0 HP!");
                switch (_onDefeatBehaviour) // command + . --> posso dirgli di scrivere tutti i possibili case
                {
                    case ON_DEFEAT_BEHAVIOUR.DISABLE:
                        gameObject.SetActive(false);
                        break;
                    case ON_DEFEAT_BEHAVIOUR.DESTROY:
                        Destroy(gameObject);
                        break;
                    case ON_DEFEAT_BEHAVIOUR.NONE:
                        break;
                    default:
                        Debug.LogError($"The option {_onDefeatBehaviour} is not recognized");
                        break;
                }
            }

        }

    }

    public void SetMaxHp(int maxHp)
    {
        _maxHp = Mathf.Max(1, maxHp);

        SetHp(_currentHp);
    }

    public void AddHp(int amount) => SetHp(_currentHp + amount);

    private void Start()
    {
        if (_fullHpOnStart)
        {
            SetMaxHp(_maxHp);
        }   
    }

}
