
namespace KickNetLib.Client.Models
{
    /// <summary>
    /// Represents the headers associated with a Kick webhook event.
    /// This record contains information about the event message such as IDs, signature, timestamp, version, and event type.
    /// </summary>
    public record WebHookHeader(
        Ulid KickEventMessageId,
        Ulid KickEventSuscriptionId,
        string KickEvensSignature,
        DateTimeOffset KickEventMessageTimestamp,
        string KickEventVersion,
        string KickEventType
    )
    { }
}
