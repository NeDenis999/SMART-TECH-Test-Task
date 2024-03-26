using Zenject;

namespace Game
{
    public class GameInstaller : MonoInstaller
    {
        private GameData _gameData = new GameData();
        
        public override void InstallBindings()
        {
            Bind(_gameData);
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