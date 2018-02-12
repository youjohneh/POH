using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Awaken : MonoBehaviour {

    public GameObject objectToWake;

    public void wakeUp()
    {
        objectToWake.SetActive(true);
    }


}
