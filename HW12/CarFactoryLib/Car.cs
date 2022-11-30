using System.Text;
using CarFactoryLib.components;

namespace CarFactoryLib;

public record Car(
    ICarBody CarBody,
    IEngine Engine,
    IChassis Chassis,
    ITransmission Transmission,
    IDashboard Dashboard,
    IStereoSystem StereoSystem
)
{
    public override string ToString()
    {
        var builder = new StringBuilder();

        builder.AppendLine("Car:");
        builder.AppendLine($"\tBody number: {CarBody.Number}");
        builder.AppendLine($"\tEngine cylinders: {Engine.CylinderCount}");
        builder.AppendLine($"\tChassis cylinders: {Chassis.WheelsCount}");
        builder.AppendLine($"\tTransmission: {Transmission.DriveType}");
        builder.AppendLine($"\tDashboard: Speed = {Dashboard.Speed}, Temperature = {Dashboard.Temperature}");
        builder.AppendLine($"\tStereo System: Volume = {StereoSystem.Volume}");
        
        return builder.ToString();
    }
}
