# Codara Architecture

## Layers

- `Codara.Domain`: Pure C# models and rules. No Unity API reference.
- `Codara.Application`: Use cases, service contracts, scene flow and offline queue rules.
- `Codara.Infrastructure`: Unity, filesystem and future Firebase adapters.
- `Codara.Presentation`: MonoBehaviours, composition root, loading and modal presentation.
- `Codara.Editor`: Project setup and validation tools.

Dependencies point inward toward Domain. Firebase SDK implementations are intentionally deferred; only provider-independent contracts exist.

## Initial Setup

Open the project with Unity `6000.0.36f1`, then run `Codara > Setup Project`. This creates the required data/art/prefab directories, all initial scenes, and their Build Settings entries.

The Bootstrap scene owns `ApplicationCompositionRoot`. It composes services without static singleton dependencies and persists across scene changes.

## Scene Flow

Use `ISceneTransitionService` with a value from `SceneNames`. It rejects unavailable scenes and concurrent transitions, shows loading state during the operation, and reports failures through `IErrorHandler`.

## Offline Data

`FileLocalSaveService` writes through a temporary file. `PersistentOfflineOperationQueue` restores pending operations after restart and rejects duplicate operation IDs.
