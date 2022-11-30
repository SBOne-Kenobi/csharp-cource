using CarFactoryLib;
using CarFactoryLib.components;


var factory = new CarFactory()
    .ConfigureEngine(builder => builder
        .SetCylindersCount(6)
        .ConfigureCylinder(_ => { })
    )
    .ConfigureChassis(builder => builder
        .SetWheelCount(4)
        .ConfigureWheels(wheelBuilder => wheelBuilder
            .SetSize(isBig: true)
        )
    )
    .ConfigureTransmission(builder => builder
        .SetDriveType(TransmissionDriveType.All)
    )
    .ConfigureCarBody(_ => { })
    .SetDashboard(new Dashboard())
    .SetStereoSystem(new StereoSystem());

var car1 = factory.Build();
car1.StereoSystem.Volume = 10;

var car2 = factory
    .ConfigureEngine(builder => builder.SetCylindersCount(12))
    .Build();
car2.StereoSystem.Volume = 50;

Console.WriteLine(car1);
Console.WriteLine(car2);
