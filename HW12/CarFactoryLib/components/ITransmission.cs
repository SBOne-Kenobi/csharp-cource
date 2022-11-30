namespace CarFactoryLib.components;

public interface ITransmission
{
    public TransmissionDriveType DriveType { get; }
}

public enum TransmissionDriveType
{
    Rear,
    Front,
    All,
}
