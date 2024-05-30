using UnityEngine;
using TMPro;
using System.Collections;
using System;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;
    private int _value = 0;
    private Coroutine _coroutine;
    private Boolean _isWorking = false;

    public void Restart()
    {
        if (_isWorking == true)
        {
            Stop();
        }
        else
        {
            _isWorking = true;
            _coroutine = StartCoroutine(NumberIncreaser(_value));
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Restart();
    }

    private void Stop()
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _isWorking = false;
    }

    private IEnumerator NumberIncreaser(int startValue)
    {
        float delay = 0.5f;
        var wait = new WaitForSeconds(delay);

        while (_isWorking)
        {
            startValue = _value;
            DisplayCount(startValue);
            _value++;

            yield return wait;
        }
    }

    private void DisplayCount(int count)
    {
        _text.text = count.ToString("");
    }
}
