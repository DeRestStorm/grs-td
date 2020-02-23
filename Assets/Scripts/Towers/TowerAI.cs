using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Factories;
using UnityEditor;
using UnityEngine;
using Zenject;

public class TowerAI : MonoBehaviour
{
    // Start is called before the first frame update

    [Inject] private Platform _platform;
    [Inject] private BulletFactory _bulletFactory;
    public float Range = 5f;
    private bool _coolDown;
    public float CoolDownTime = 0.4f;
    private List<GameObject> _mobs = new List<GameObject>();
    public float Speed = 6f;
    public Transform SpawnPoint;

    private void Start()
    {
        SpawnPoint = transform.Find("SpawnPoint");
        transform.position = _platform.Socket.position;
        transform.SetParent(_platform.Socket);
    }

    // Update is called once per frame
    void Update()
    {
        var mob = _mobs.FirstOrDefault();
        if (mob == null)
        {
            _mobs.Remove(mob);
            return;   
        }
        var tr = transform;
        var vector = mob.transform.position - tr.position;
        
        var newDir = Vector3.RotateTowards(tr.forward, new Vector3(vector.x,0, vector.z), 360, 0.0F);
        transform.rotation = Quaternion.LookRotation(newDir);

        if (_coolDown)
            return;
        _coolDown = true;
        StartCoroutine(nameof(Attack), mob);
    }

    private IEnumerator Attack(GameObject mob)
    {
        _bulletFactory.Create(SpawnPoint, Speed, mob);
        yield return new WaitForSeconds(CoolDownTime);
        _coolDown = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        _mobs.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        _mobs.Remove(other.gameObject);
    }
    
    
}