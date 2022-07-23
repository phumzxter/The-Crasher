using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public GameObject ThirdPerson;
    public GameObject FirstPerson;
    public int CamMode;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.V)) {
            if (CamMode == 1) {
                CamMode = 0;
        } else {
            CamMode += 1;
        }
        StartCoroutine (CamChange ());
        }
    }

    IEnumerator CamChange () {
        yield return new WaitForSeconds(0.01f);
        if (CamMode == 0) {
            ThirdPerson.SetActive(true);
            FirstPerson.SetActive(false);
        }
        if (CamMode == 1) {
            ThirdPerson.SetActive(false);
            FirstPerson.SetActive(true);
        }
    }
}