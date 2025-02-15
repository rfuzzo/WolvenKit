using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WolvenKit.RED4.CR2W.Archive;
using WolvenKit.Bundles;
using WolvenKit.Cache;
using WolvenKit.Common;
using WolvenKit.Functionality.WKitGlobal;
using WolvenKit.W3Strings;

namespace WolvenKit.Functionality.Controllers
{
    public abstract class GameControllerBase
    {
        #region Properties

        public static string ManagerCacheDir => Path.Combine(AppContext.BaseDirectory, "Config");
        public static string WorkDir => Path.Combine(AppContext.BaseDirectory, "tmp_workdir");
        public static string XBMDumpPath => Path.Combine(ManagerCacheDir, "__xbmdump_3768555366.csv");

        #endregion Properties

        #region Methods

        public static string GetManagerPath(EManagerType type)
        {
            switch (type)
            {
                case EManagerType.BundleManager:
                    return Path.Combine(ManagerCacheDir, "bundle_cache.json");

                case EManagerType.CollisionManager:
                    return Path.Combine(ManagerCacheDir, "collision_cache.json");

                case EManagerType.SoundManager:
                    return Path.Combine(ManagerCacheDir, "sound_cache.json");

                case EManagerType.W3StringManager:
                    return Path.Combine(ManagerCacheDir, "string_cache.bin");

                case EManagerType.TextureManager:
                    return Path.Combine(ManagerCacheDir, "texture_cache.json");

                case EManagerType.ArchiveManager:
                    return Path.Combine(ManagerCacheDir, "archive_cache.json");

                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public static string GetManagerVersion(EManagerType type)
        {
            switch (type)
            {
                case EManagerType.BundleManager:
                    return BundleManager.SerializationVersion;

                case EManagerType.CollisionManager:
                    return CollisionManager.SerializationVersion;

                case EManagerType.SoundManager:
                    return SoundManager.SerializationVersion;

                case EManagerType.W3StringManager:
                    return W3StringManager.SerializationVersion;

                case EManagerType.TextureManager:
                    return TextureManager.SerializationVersion;

                case EManagerType.ArchiveManager:
                    return ArchiveManager.SerializationVersion;

                case EManagerType.Max:
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        public abstract List<IGameArchiveManager> GetArchiveManagersManagers();

        public abstract List<string> GetAvaliableClasses();

        public abstract Task HandleStartup();

        public abstract Task<bool> PackageMod();

        public abstract Task<bool> PackAndInstallProject();

        #endregion Methods
    }
}
