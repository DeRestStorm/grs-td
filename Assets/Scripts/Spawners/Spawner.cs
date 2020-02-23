using System;
using System.Collections;
using BezierSolution;
using Factories;
using UnityEngine;
using Zenject;

namespace Spawners
{
    public class Spawner: MonoBehaviour
    {
        public BezierSpline Spline;
        [Inject]
        private EnemyFactory _enemyFactory;
        
        private void Start()
        {
            StartCoroutine(nameof(Run));


        }


        private IEnumerator Run()
        {
            yield return null;
            
            _enemyFactory.Create(transform, 5, Spline);
            
            yield return new WaitForSeconds(3);
            _enemyFactory.Create(transform, 6, Spline);
            yield return new WaitForSeconds(3);
            _enemyFactory.Create(transform, 6, Spline);
            yield return new WaitForSeconds(3);
            _enemyFactory.Create(transform, 6, Spline);
            yield return new WaitForSeconds(3);
            _enemyFactory.Create(transform, 6, Spline);
            yield return new WaitForSeconds(3);
            _enemyFactory.Create(transform, 6, Spline);
        }
    }
}