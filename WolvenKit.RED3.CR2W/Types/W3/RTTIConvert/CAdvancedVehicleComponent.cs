using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CAdvancedVehicleComponent : CVehicleComponent
	{
		[Ordinal(1)] [RED("passengerSeats", 2,0)] 		public CArray<CPtr<CSeatComponent>> PassengerSeats { get; set;}

		[Ordinal(2)] [RED("inputContext")] 		public CName InputContext { get; set;}

		public CAdvancedVehicleComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CAdvancedVehicleComponent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}