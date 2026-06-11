using System;
using Codara.Domain;

namespace Codara.Application
{
    public sealed class OnboardingService
    {
        private readonly IOnboardingRepository repository;

        public OnboardingService(IOnboardingRepository repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
            State = repository.Load();
        }

        public OnboardingState State { get; }

        public void Update(Action<OnboardingState> change)
        {
            change?.Invoke(State);
            repository.Save(State);
        }

        public void Advance()
        {
            State.Advance();
            repository.Save(State);
        }
    }
}
