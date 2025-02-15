using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class CWanderPointComponent : CWayPointComponent
	{
		[Ordinal(1)] [RED("connectedPoints", 2,0)] 		public CArray<SWanderPointConnection> ConnectedPoints { get; set;}

		[Ordinal(2)] [RED("wanderPointRadius")] 		public CFloat WanderPointRadius { get; set;}

		public CWanderPointComponent(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static new CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new CWanderPointComponent(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}