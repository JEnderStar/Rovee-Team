using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningText : MonoBehaviour
{
    [SerializeField] GameObject NuevaEcijaWarning;
    [SerializeField] GameObject BaguioWarning;

    [SerializeField] GameObject NuevaText;
    [SerializeField] GameObject BaguioText;

    float checkDistance;
    float checkDistance1;

    private void Update()
    {
        checkDistance = Vector3.Distance(this.transform.position, NuevaEcijaWarning.transform.position);
        checkDistance1 = Vector3.Distance(this.transform.position, BaguioWarning.transform.position);

        if (checkDistance <= 20f)
        {
            NuevaText.SetActive(true);
            // isInteractActive = true;
        }
        else if (checkDistance1 <= 20f)
        {
            BaguioText.SetActive(true);
            // isInteractActive = false;
        }
        else
        {
            NuevaText.SetActive(false);
            BaguioText.SetActive(false);
        }
    }
}
