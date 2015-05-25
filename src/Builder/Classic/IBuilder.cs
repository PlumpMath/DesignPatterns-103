using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MedikzWorks.PracticalPattern.Builder.Classic
{
    public class Vehicle
    {
        public IEnumerable<string> Wheels { get; set; }
        public IEnumerable<string> Lights { get; set; }
    }

    /// <summary>
    /// abstract builder
    /// </summary>
    public abstract class VehicleBuilderBase
    {
        public Vehicle Vehicle { get; protected set; }

        public virtual void Create()
        {
            Vehicle = new Vehicle();
        }

        public abstract void AddWheels();
        public abstract void AddLights();
    }

    /// <summary>
    /// concrete builder
    /// </summary>
    public class CarBuilder:VehicleBuilderBase
    {
        #region VehicleBuilderBase Members
        public override void AddWheels()
        {
            Vehicle.Wheels = new string[] { "front","front","back","back"};
        }

        public override void AddLights()
        {
            Vehicle.Lights = new string[] {"front","front","back","back" };
        }
        #endregion
    }

    public class BicycleBuilder:VehicleBuilderBase
    {
        #region VehicleBuilderBase Members
        public override void AddWheels()
        {
            Vehicle.Wheels = new string[] { "front","back" };
        }

        public override void AddLights()
        {
            Vehicle.Lights = null;
        }
        #endregion
    }

    // Director
    public class VehicleMaker
    {
        public VehicleBuilderBase Builder { get; set; }
        public Vehicle Vehicle { get { return Builder.Vehicle; } }

        public void Construct()
        {
            Builder.Create();
            Builder.AddWheels();
            Builder.AddLights();
        }
    }
}
