using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupDisabler : MonoBehaviour {

	public void startDisable()
    {
        StartCoroutine(Deactivate());
    }

    IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(0.05f);
        this.gameObject.SetActive(false);
    }
}
