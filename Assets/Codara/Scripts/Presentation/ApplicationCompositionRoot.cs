using Codara.Application;
using Codara.Domain;
using Codara.Infrastructure;
using Codara.Presentation.DesignSystem;
using UnityEngine;
using System.Collections.Generic;

namespace Codara.Presentation
{
    public sealed class ApplicationCompositionRoot : MonoBehaviour
    {
        [SerializeField] private LoadingScreen loadingScreen;
        [SerializeField] private GlobalModal globalModal;

        public IServiceResolver Services { get; private set; }

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);

            loadingScreen = loadingScreen != null ? loadingScreen : gameObject.AddComponent<LoadingScreen>();
            globalModal = globalModal != null ? globalModal : gameObject.AddComponent<GlobalModal>();
            if (DesignSystemContext.Theme == null)
            {
                gameObject.AddComponent<DesignSystemBootstrap>();
            }

            var registry = new ServiceRegistry();
            var errors = new ErrorHandler();
            var loader = new UnitySceneLoader();
            var saveService = new FileLocalSaveService();
            var connectionMonitor = gameObject.AddComponent<InternetConnectionMonitorBehaviour>();
            var onboardingRepository = new LocalOnboardingRepository(saveService);
            var authenticationService = new AuthenticationService(new List<IAuthenticationProvider>
            {
                new GuestAuthenticationProvider()
            });

            registry.Register(new ApplicationState());
            registry.Register<ILocalSaveService>(saveService);
            registry.Register<IInternetConnectionMonitor>(connectionMonitor);
            registry.Register<IOfflineOperationQueue>(new PersistentOfflineOperationQueue(saveService));
            registry.Register<IOnboardingRepository>(onboardingRepository);
            registry.Register(authenticationService);
            registry.Register<IAuthenticationService>(authenticationService);
            registry.Register(new OnboardingService(onboardingRepository));
            registry.Register<IErrorHandler>(errors);
            registry.Register<ILoadingScreen>(loadingScreen);
            registry.Register<IModalService>(globalModal);
            registry.Register<ISceneLoader>(loader);
            registry.Register<ISceneTransitionService>(new SceneTransitionService(loader, loadingScreen, errors));

            errors.ErrorRaised += Debug.LogException;
            Services = registry;
        }
    }
}
