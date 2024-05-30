using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _value = 0;
    private Coroutine _coroutine;
    private bool _isWorking = false;

    public void ActivateCoroutine()
    {
        if (_isWorking == true)
        {
            StopCoroutine();
        }
        else
        {
            _isWorking = true;
            _coroutine = StartCoroutine(IncreaseOfNumber());
        }
    }

    private void StopCoroutine()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _isWorking = false;
    }

    private IEnumerator IncreaseOfNumber()
    {
        float delay = 0.5f;
        var wait = new WaitForSeconds(delay);

        while (_isWorking)
        {
            DisplayCount(++_value);

            yield return wait;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            ActivateCoroutine();
    }

    private void DisplayCount(int count)
    {
        _text.text = count.ToString();
    }
}
