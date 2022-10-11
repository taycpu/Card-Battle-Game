using UnityEngine;

namespace GameAssets.Scripts.Misc
{
    public abstract class Manager:MonoBehaviour
    {
        public abstract void Initialize();

        public abstract bool IsReady();
    }
}
