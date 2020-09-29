using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerStar : MonoBehaviour
{
    [SerializeField]
    private GameObject _starPrefab;
    [SerializeField]
    private bool _canThrow = true;
    [SerializeField]
    private float _starReset;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && _canThrow)
        {
            Instantiate(_starPrefab, transform.position, Quaternion.identity);
            StartCoroutine(StarResetRoutine());
        }
    }
    IEnumerator StarResetRoutine()
    {
        _canThrow = false;
        yield return new WaitForSeconds(_starReset);
        _canThrow = true;
    }
}
