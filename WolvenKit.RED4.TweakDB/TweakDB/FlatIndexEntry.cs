using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using WolvenKit.RED4.TweakDB.Types;
using Activator = System.Activator;

namespace WolvenKit.RED4.TweakDB
{
    [DataContract(Namespace = "")]
    [StructLayout(LayoutKind.Explicit, Size = 12)]
    public struct FlatIndexEntry
    {
        [DataMember]
        [FieldOffset(0)]
        public ulong Hash;

        [DataMember]
        [FieldOffset(8)]
        public uint Size;
    }

    public class FlatIndexEntryWrapper
    {
        #region Fields

        [XmlIgnore]
        [NonSerialized()]
        private readonly TweakDBFile _tweakDb;

        #endregion

        #region Constructors

        public FlatIndexEntryWrapper(FlatIndexEntry flatIndex, TweakDBFile tweakDb)
        {
            _tweakDb = tweakDb;
            FlatIndexEntry = flatIndex;
        }

        #endregion

        #region Properties

        public FlatIndexEntry FlatIndexEntry { get; set; }
        public Type Type => _tweakDb.Types[FlatIndexEntry.Hash];

        #endregion

        #region Methods

        public IVariable Create()
        {
            return (IVariable)Activator.CreateInstance(Type);
        }

        #endregion
    }
}
