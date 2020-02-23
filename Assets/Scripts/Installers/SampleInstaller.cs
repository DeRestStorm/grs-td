using BezierSolution;
using Entities;
using Factories;
using UnityEngine;
using Zenject;

public class SampleInstaller : MonoInstaller
{
    public GameObject BulletPrefab;
    public GameObject EnemyPrefab;
    public GameObject TowerPrefab;

    public override void InstallBindings()
    {
        Container.Bind<string>().FromInstance("Hello World!");
        Container.Bind<Greeter>().AsSingle().NonLazy();
        Container.BindFactory<Transform, float, GameObject, Bullet, BulletFactory>()
            .FromNewComponentOnNewPrefab(BulletPrefab);
        Container.BindFactory<Transform, float, BezierSpline, Enemy, EnemyFactory>()
            .FromNewComponentOnNewPrefab(EnemyPrefab);
        Container.BindFactory<Platform, TowerAI, TowerFactory>()
            .FromNewComponentOnNewPrefab(TowerPrefab);
    }

    public class Greeter
    {
        public Greeter(string message)
        {
            Debug.Log(message);
        }
    }
}