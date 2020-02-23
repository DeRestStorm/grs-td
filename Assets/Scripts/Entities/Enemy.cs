using System;
using System.Runtime.InteropServices;
using BezierSolution;
using UnityEngine;
using Zenject;

namespace Entities
{
    [RequireComponent(typeof(BezierWalkerWithSpeed))]
    public class Enemy : MonoBehaviour
    {
        [Inject]
        private Transform _spawnPoint;
        [Inject]
        private float _speed;
        [Inject]
        private BezierSpline _spline;

        private void Start()
        {
            var walker = GetComponent<BezierWalkerWithSpeed>();
            walker.spline = _spline;
            walker.speed = _speed;
        }
    }
}