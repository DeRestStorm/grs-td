using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Behaviours;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    [Inject] public Transform StartPosition;
    [Inject] private float _speed;
    [Inject] private GameObject _target;

    void Start()
    {
        var transform1 = transform;
        transform1.position = StartPosition.position;
        transform1.rotation = StartPosition.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (_target == null)
        {
            Destroy(gameObject);
            return;
        }

        float step = _speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, step);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != _target)
            return;
        Debug.Log(other.gameObject.name);
        other.GetComponentInParent<Health>().Damage(Random.Range(5, 30));
        Destroy(gameObject);
    }
}