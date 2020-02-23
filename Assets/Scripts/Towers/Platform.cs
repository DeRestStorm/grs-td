using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Factories;
using UnityEngine;
using Zenject;

public class Platform : MonoBehaviour
{
    [Inject]
    public TowerFactory _TowerFactory;
    public Transform Socket;
    private void OnMouseDown()
    {
        _TowerFactory.Create(this);
    }
}
