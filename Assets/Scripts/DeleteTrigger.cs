using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteTrigger : MonoBehaviour {
    public GameObject deleteTarget;

	public void OnTriggerEnter2D(Collider2D Other)
    {
        if(Other.tag == "Player")
        {
            Destroy(deleteTarget);
            Destroy(this.gameObject);
        }
    }
}
