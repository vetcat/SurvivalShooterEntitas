using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "GamePrefabsInstaller", menuName = "Installers/GamePrefabsInstaller")]
public class GamePrefabsInstaller : ScriptableObjectInstaller<GamePrefabsInstaller>
{
    public override void InstallBindings()
    {
    }
}