using System.IO;
using System.Runtime.Serialization;
using WolvenKit.RED3.CR2W.Reflection;
using FastMember;
using static WolvenKit.RED3.CR2W.Types.Enums;


namespace WolvenKit.RED3.CR2W.Types
{
	[DataContract(Namespace = "")]
	[REDMeta]
	public class SCameraAnimationDefinition : CVariable
	{
		[Ordinal(1)] [RED("animation")] 		public CName Animation { get; set;}

		[Ordinal(2)] [RED("priority")] 		public CInt32 Priority { get; set;}

		[Ordinal(3)] [RED("blendIn")] 		public CFloat BlendIn { get; set;}

		[Ordinal(4)] [RED("blendOut")] 		public CFloat BlendOut { get; set;}

		[Ordinal(5)] [RED("weight")] 		public CFloat Weight { get; set;}

		[Ordinal(6)] [RED("speed")] 		public CFloat Speed { get; set;}

		[Ordinal(7)] [RED("loop")] 		public CBool Loop { get; set;}

		[Ordinal(8)] [RED("reset")] 		public CBool Reset { get; set;}

		[Ordinal(9)] [RED("additive")] 		public CBool Additive { get; set;}

		[Ordinal(10)] [RED("exclusive")] 		public CBool Exclusive { get; set;}

		public SCameraAnimationDefinition(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name){ }

		public static CVariable Create(CR2WFile cr2w, CVariable parent, string name) => new SCameraAnimationDefinition(cr2w, parent, name);

		public override void Read(BinaryReader file, uint size) => base.Read(file, size);

		public override void Write(BinaryWriter file) => base.Write(file);

	}
}