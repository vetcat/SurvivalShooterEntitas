using UnityEngine;

namespace Libs.OpenCore.Ecs
{
    public interface IPrefabsProvider
    {
        GameObject Get(string name);
    }
}