using Assets.Script.Page;
using Cysharp.Threading.Tasks;
using System.Threading;
using VContainer.Unity;

namespace Assets.Script
{
    public class SampleStarter : IInitializable
    {
        public SampleStarter()
        {
            UnityEngine.Debug.Log("Start Sample");
        }

        public void Initialize()
        {
            throw new System.NotImplementedException();
        }
    }
}
