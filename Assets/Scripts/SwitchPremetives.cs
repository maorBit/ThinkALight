using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPremetives : MonoBehaviour
{
    public Premetive ScreenModel;
    public Premetive myModel;

    private void Start()
    {
        myModel = GetComponent<Premetive>();
        RayCast.OnHitRayCast += hitModelFromScreen;
    }

    public void hitModelFromScreen(Premetive selectedModel)
    {
        ScreenModel = selectedModel;
    }

    public void OnClickSwitch()
    {

        if (ScreenModel != null)
        {
            Premetive premitive = ScreenModel.GetComponent<Premetive>();
            premitive.OnChangePremitive(myModel.modelType);

        }
    }
}
