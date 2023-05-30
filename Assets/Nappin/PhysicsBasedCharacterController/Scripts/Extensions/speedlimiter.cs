using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedlimiter : MonoBehaviour
{
    public Cinemachine.CinemachineDollyCart cartScript;
    public Transform player1;
    public Transform player2;
    public int slowSpeed;
    public int normalSpeed;
    public int maxDistance;

    // Start is called before the first frame update
    void Awake()
    {
        cartScript = GetComponent<Cinemachine.CinemachineDollyCart>();
    }

    // Update is called once per frame
    void Update()
    {
        float player1Distance = Vector3.Distance(transform.position, player1.position);
        float player2Distance = Vector3.Distance(transform.position, player2.position);

        if (player1Distance > maxDistance || player2Distance > maxDistance)
        {
            cartScript.m_Speed = slowSpeed;
        }

        else

        {
            cartScript.m_Speed = normalSpeed;
        }
    }
}
