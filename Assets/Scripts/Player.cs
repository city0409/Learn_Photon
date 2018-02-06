using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Photon.MonoBehaviour 
{
    [SerializeField]
    private float moveSpeed = 10f;
    [SerializeField]
    private float rotateSpeed = 10f;

    private PhotonView photonView;

    private Vector3 targetPosition;
    private Quaternion targetRotation;

    private void Awake() 
	{
        photonView = GetComponent<PhotonView>();

    }
	
	private void Update () 
	{
        if (photonView.isMine)
            Movement();
        else
            SmoothMove();
	}

    //Invoke by Photon
    private void OnPhotonSerializeView(PhotonStream stream,PhotonMessageInfo info)
    {
        if (stream .isWriting)
        {
            stream.SendNext(transform.position);
            stream.SendNext(transform.rotation);
        }
        else
        {
            targetPosition = (Vector3)stream.ReceiveNext();
            targetRotation = (Quaternion)stream.ReceiveNext();
        }
    }

    private void Movement()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(transform.forward * Time.deltaTime * vertical * moveSpeed);

        transform.Rotate(new Vector3(0, horizontal * rotateSpeed * Time.deltaTime, 0));
    }

    private void SmoothMove()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.25f);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.25f);
    }
}
