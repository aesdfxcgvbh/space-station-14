namespace Content.Server.Speech.EntitySystems;	

using Content.Server.Speech.Components;

public sealed class SecretListeningSystem : EntitySystem
{
	public override void Initialize()
    {
        base.Initialize();
        SubscribeLocalEvent<ActiveListenerComponent, ListenAttemptEvent>(OnListen);
    }

	private void OnListen(EntityUid listener, ActiveListenerComponent component, ListenAttemptEvent args)
    {
        if (HasComp<SecretMessageSpeakerComponent>(args.Source))
        {
            if (!HasComp<SecretMessageListenerComponent>(listener))
                args.Cancel();
        }
    }
}