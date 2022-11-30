namespace CarFactoryLib.components.factory;

public class TransmissionBuilder
{
    private TransmissionDriveType _type = TransmissionDriveType.Rear;

    public TransmissionBuilder SetDriveType(TransmissionDriveType type)
    {
        _type = type;
        return this;
    }

    private class Transmission : ITransmission
    {
        public Transmission(TransmissionDriveType driveType)
        {
            DriveType = driveType;
        }

        public TransmissionDriveType DriveType { get; }
    }
    
    public ITransmission Build()
    {
        return new Transmission(_type);
    }
    
}