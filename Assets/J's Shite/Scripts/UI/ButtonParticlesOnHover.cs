using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public interface ButtonParticlesOnHover : IEventSystemHandler
{
    // https://docs.unity3d.com/Packages/com.unity.ugui@2.0/api/UnityEngine.EventSystems.IPointerDownHandler.html 

    void IPointerEnterHandler()
    {
        // make particles go brrr
    }

    void IPointerExitHandler ()
    {
        // get rid of them for now
    }
}
