﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvatarInputConverter : MonoBehaviour
{
    // Avatar Transforms
    public Transform mainAvatarTransform;
    public Transform avatarHead;
    public Transform avatarBody;

    public Transform avatarHand_Left;
    public Transform avatarHand_Right;

    // Oculus Transforms
    public Transform oculusHead;

    public Transform oculusHand_Left;
    public Transform oculusHand_Right;

    Vector3 displacement = new Vector3(0.0f, 0.8f, 0.07f);

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        avatarHead.position = Vector3.Lerp(avatarHead.position, oculusHead.position, 0.5f);

        mainAvatarTransform.position = avatarHead.position - displacement;

        avatarHead.rotation = Quaternion.Lerp(avatarHead.rotation, oculusHead.rotation, 0.5f);
        avatarBody.rotation = Quaternion.Lerp(avatarBody.rotation, Quaternion.Euler(new Vector3(0, avatarHead.rotation.eulerAngles.y, 0)), 0.5f);

        // Hand
        avatarHand_Right.position = Vector3.Lerp(avatarHand_Right.position, oculusHand_Right.position, 0.5f);
        avatarHand_Right.rotation = Quaternion.Lerp(avatarHand_Right.rotation, oculusHand_Right.rotation, 0.5f);

        avatarHand_Left.position = Vector3.Lerp(avatarHand_Left.position, oculusHand_Left.position, 0.5f);
        avatarHand_Left.rotation = Quaternion.Lerp(avatarHand_Left.rotation, oculusHand_Left.rotation, 0.5f);
    }
}