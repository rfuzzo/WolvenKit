using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WolvenKit.Common.Model.Cr2w;
using WolvenKit.RED3.CR2W.Reflection;

namespace WolvenKit.RED3.CR2W.Types
{
    /// <summary>
    /// A generic wrapper class for a single CVariable, with the nameID left out
    /// Format: [uint size] [ushort typeID] [byte[size] data]
    /// </summary>
    [DataContract(Namespace = "")]
    [REDMeta()]
    public class CVariantSizeType : CVariable, IBufferVariantAccessor
    {
        public IEditableVariable Variant { get; set; }

        public CVariantSizeType(CR2WFile cr2w, CVariable parent, string name) : base(cr2w, parent, name)
        {

        }

        public override void Read(BinaryReader file, uint size)
        {
            CVariable parsedvar = null;
            var varsize = file.ReadUInt32();
            var buffer = file.ReadBytes((int)varsize - 4);
            using (var ms = new MemoryStream(buffer))
            using (var br = new BinaryReader(ms))
            {

                var typeId = br.ReadUInt16();
                var typename = cr2w.Names[typeId].Str;

                parsedvar = CR2WTypeManager.Create(typename, nameof(Variant), cr2w, this);
                parsedvar.IsSerialized = true;
                parsedvar.Read(br, size);
            }

            Variant = parsedvar;
        }

        public override void Write(BinaryWriter file)
        {

            UInt32 varsize = 4 + 2; //4 for the uint32 varsize, 2 for uint16 typeID
            byte[] varvalue;

            // use a temporary stream to write the variable and get the length of the variable
            using (var ms = new MemoryStream())
            using (var bw = new BinaryWriter(ms))
            {
                Variant.Write(bw);
                varsize += (UInt32)ms.Length;
                varvalue = ms.ToArray();
            }

            // write variable
            file.Write(varsize);
            file.Write((Variant as CVariable).GettypeId());
            file.Write(varvalue);
        }

        public override string ToString()
        {
            return Variant.ToString();
        }

        public override CVariable Copy(ICR2WCopyAction context)
        {
            var copy = (CVariantSizeType)base.Copy(context);
            if (Variant != null)
                copy.Variant = Variant.Copy(context);
            return copy;
        }

        public override List<IEditableVariable> GetEditableVariables() => Variant?.GetEditableVariables();

        public static CVariable Create(CR2WFile cr2w, CVariable parent, string name)
        {
            return new CVariantSizeType(cr2w, parent, name);
        }
    }
}
