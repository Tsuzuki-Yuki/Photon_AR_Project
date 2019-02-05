using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PhotonRx;
using UniRx;

namespace Connection
{
    public class SubscribeConnection : MonoBehaviour
    {
        void Start()
        {
            this.OnConnectedToPhotonAsObservable()
                .Subscribe(_ => Debug.Log("Connected"));

            this.OnFailedToConnectToPhotonAsObservable()
                .Subscribe(_ => Debug.Log("Failed"));
            
            PhotonNetwork.ConnectUsingSettings( null );
        }
    }
}
