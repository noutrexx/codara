using System;
using Codara.Application;
using UnityEngine;

namespace Codara.Infrastructure
{
    public sealed class InternetConnectionMonitorBehaviour : MonoBehaviour, IInternetConnectionMonitor
    {
        [SerializeField, Min(1f)] private float refreshIntervalSeconds = 5f;

        private float nextRefreshTime;

        public bool IsOnline { get; private set; }
        public event Action<bool> ConnectionChanged;

        private void Awake()
        {
            IsOnline = ReadConnectivity();
        }

        private void Update()
        {
            if (Time.unscaledTime < nextRefreshTime)
            {
                return;
            }

            nextRefreshTime = Time.unscaledTime + refreshIntervalSeconds;
            Refresh();
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                Refresh();
            }
        }

        public void Refresh()
        {
            var current = ReadConnectivity();
            if (current == IsOnline)
            {
                return;
            }

            IsOnline = current;
            ConnectionChanged?.Invoke(current);
        }

        private static bool ReadConnectivity()
        {
            return UnityEngine.Application.internetReachability != NetworkReachability.NotReachable;
        }
    }
}
