using UnityEngine;
using Zenject;

namespace Game
{
    public class LevelInstaller : MonoInstaller
    {
        [SerializeField]
        private WinScreen _winScreen;
        
        [SerializeField]
        private LoseScreen _loseScreen;

        [SerializeField]
        private LevelGenerator _levelGenerator;

        [SerializeField]
        private Character _character;
        
        [SerializeField]
        private InputManager _inputManager;

        public override void InstallBindings()
        {
            Bind(_winScreen);
            Bind(_loseScreen);
            Bind(_levelGenerator);
            Bind(_character);
            Bind(_inputManager);
        }
        
        private void Bind<T>(T obj)
        {
            Container.Bind<T>()
                .FromInstance(obj)
                .AsSingle()
                .NonLazy();
        }
    }
}