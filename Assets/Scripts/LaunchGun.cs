using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class LaunchGun : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject launchGun;
    public void Fire()
    {
        GameObject projectTile = Instantiate(launchGun, launchPoint.position, launchGun.transform.rotation);
        Vector3 origScale = projectTile.transform.localScale;
        projectTile.transform.localScale = new Vector3(origScale.x * transform.localScale.x > 0 ? 1: -1
            , origScale.y
            , origScale.z);

    }
}
