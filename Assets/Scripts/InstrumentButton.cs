using UnityEngine;

namespace TestTask
{
    public abstract class InstrumentButton : MonoBehaviour
    {
        public virtual void OnClick()
        {
            Debug.Log(name + " was pressed!");
        }
    }
}
