using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Codara.Domain;

namespace Codara.Application
{
    public interface ISceneTransitionService
    {
        bool IsTransitioning { get; }
        Task LoadAsync(string sceneName, CancellationToken cancellationToken = default);
    }

    public interface ISceneLoader
    {
        bool CanLoad(string sceneName);
        Task LoadAsync(string sceneName, CancellationToken cancellationToken);
    }

    public interface ILocalSaveService
    {
        bool Exists(string key);
        string Load(string key);
        void Save(string key, string content);
        void Delete(string key);
    }

    public interface IInternetConnectionMonitor
    {
        bool IsOnline { get; }
        event Action<bool> ConnectionChanged;
        void Refresh();
    }

    public interface IOfflineOperationQueue
    {
        int Count { get; }
        IReadOnlyList<OfflineOperation> Pending { get; }
        bool Enqueue(OfflineOperation operation);
        bool Remove(string operationId);
        void Clear();
    }

    public interface IErrorHandler
    {
        event Action<Exception> ErrorRaised;
        void Handle(Exception exception);
    }

    public interface ILoadingScreen
    {
        bool IsVisible { get; }
        void Show();
        void Hide();
    }

    public interface IModalService
    {
        bool IsVisible { get; }
        void Show(string title, string message, Action onClosed = null);
        void Close();
    }
}

