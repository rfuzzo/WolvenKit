#include "gtest/gtest.h"
#include "cr2w/bundledictionary.h"
#include "cr2w/bundle.h"
#include "cr2w/bundlemanager.h"
#include "cr2w/meshloader.h"
#include "cr2w/hashdictionary.h"
#include <filesystem>
#include <fstream>

std::string exedir = "D:\\SteamLibrary\\steamapps\\common\\The Witcher 3\\bin\\x64";

#define SKIP_GENERATING_RUNTIME_DATA 1

#ifndef SKIP_GENERATING_RUNTIME_DATA
TEST(TestBundle, TestGenerateTableOfContents) {
    WolvenEngine::SetWitcherExePath(exedir.c_str());

    // redirect to a file because there is a lot of output!
    std::ofstream out("out.txt");
    std::streambuf* coutbuf = std::cout.rdbuf(); //save old buf
    std::cout.rdbuf(out.rdbuf());

    bool rc = WolvenEngine::CreateTableOfContentsFromBundles();
    EXPECT_TRUE(rc);

    std::cout.rdbuf(coutbuf); //reset to standard output again
}

TEST(TestBundle, TestGeneratePathHashes) {

    std::string path = "pathhashes.csv";
    std::string outputPath = path;
    outputPath.replace(outputPath.rfind("csv"), 3, "bin");

    WolvenEngine::CreateBinFromCSV(path);
    EXPECT_TRUE(std::filesystem::exists(outputPath));
}
#endif

TEST(TestBundle, TestLookup) {
    std::cout << "Current path is " << std::filesystem::current_path() << std::endl;

    WolvenEngine::LoadRawPathHashes("rawpathhashes.bin");

    std::string asset = "animations\\dwarf\\movement\\dwarf_reaction.w2anims.56.buffer";

    WolvenEngine::BundleEntry bundle;
    bool rc = WolvenEngine::GetFileInfo(asset, bundle);
    EXPECT_TRUE(rc);

    asset = "characters\\models\\crowd_npc\\inquisitor_soldier_lvl2\\items\\model\\i_05_mb__iquisitor_soldier_lvl2_d01.xbm";

    rc = WolvenEngine::GetFileInfo(asset, bundle);
    EXPECT_TRUE(rc);
}

TEST(TestBundle, TestGetBundleName) {
    std::cout << "Current path is " << std::filesystem::current_path() << std::endl;
    std::string expectedFilename = "D:\\Program Files (x86)\\GOG Galaxy\\Games\\The Witcher 3 Wild Hunt\\content\\content0\\bundles\\blob.bundle";

    WolvenEngine::LoadRawPathHashes("rawpathhashes.bin");
    WolvenEngine::SetWitcherExePath(exedir.c_str());

    std::string filename = WolvenEngine::GetBundlePath(32);

    EXPECT_EQ(filename, expectedFilename);
}


TEST(TestBundle, TestMeshLoad) {
    WolvenEngine::LoadRawPathHashes("rawpathhashes.bin");
    WolvenEngine::SetWitcherExePath(exedir.c_str());

    std::string asset = "characters/models/animals/bat/model/t_01__bat.w2mesh";

    WolvenEngine::BundleEntry bundle;
    bool rc = WolvenEngine::GetFileInfo(asset, bundle);
    EXPECT_TRUE(rc);

    std::string bundlePath = WolvenEngine::GetBundlePath(bundle.index);

    WolvenEngine::Bundle archive;
    rc = archive.open(bundlePath.c_str());
    EXPECT_TRUE(rc);

    WolvenEngine::File fp;
    rc = archive.load(bundle.offset, bundle.compressedSize, bundle.uncompressedSize, bundle.compression, fp);
    EXPECT_TRUE(rc);

    // write out the file for comparison to the unbundled version
    FILE* out = nullptr;
    if (fopen_s(&out, "t_01__bat.w2mesh", "wb") == 0)
    {
        fwrite(fp.getBuffer<char*>(), fp.size(), 1, out);
        fclose(out);
    }
}

TEST(TestBundle, TestMeshLoad2) {
    WolvenEngine::LoadRawPathHashes("rawpathhashes.bin");
    WolvenEngine::SetWitcherExePath(exedir.c_str());

    std::string asset = "items\\work\\bottle_01\\bottle_open.w2mesh";

    WolvenEngine::BundleEntry bundle;
    bool rc = WolvenEngine::GetFileInfo(asset, bundle);
    EXPECT_TRUE(rc);

    std::string bundlePath = WolvenEngine::GetBundlePath(bundle.index);

    WolvenEngine::Bundle archive;
    rc = archive.open(bundlePath.c_str());
    EXPECT_TRUE(rc);

    WolvenEngine::File fp;
    rc = archive.load(bundle.offset, bundle.compressedSize, bundle.uncompressedSize, bundle.compression, fp);
    EXPECT_TRUE(rc);

    // write out the file for comparison to the unbundled version
    FILE* out = nullptr;
    if (fopen_s(&out, "bottle_open.w2mesh", "wb") == 0)
    {
        fwrite(fp.getBuffer<char*>(), fp.size(), 1, out);
        fclose(out);
    }
}

TEST(TestBundle, TestMeshLoad3) {
    WolvenEngine::LoadRawPathHashes("rawpathhashes.bin");
    WolvenEngine::SetWitcherExePath(exedir.c_str());

    std::string asset = "items\\work\\bottle_01\\bottle_open.w2mesh.1.buffer";

    WolvenEngine::BundleEntry bundle;
    bool rc = WolvenEngine::GetFileInfo(asset, bundle);
    EXPECT_TRUE(rc);

    std::string bundlePath = WolvenEngine::GetBundlePath(bundle.index);

    WolvenEngine::Bundle archive;
    rc = archive.open(bundlePath.c_str());
    EXPECT_TRUE(rc);

    WolvenEngine::File fp;
    rc = archive.load(bundle.offset, bundle.compressedSize, bundle.uncompressedSize, bundle.compression, fp);
    EXPECT_TRUE(rc);

    // write out the file for comparison to the unbundled version
    FILE* out = nullptr;
    if (fopen_s(&out, "bottle_open.w2mesh.1.buffer", "wb") == 0)
    {
        fwrite(fp.getBuffer<char*>(), fp.size(), 1, out);
        fclose(out);
    }
}

TEST(TestBundle, TestMeshLoadArchive) {
    WolvenEngine::LoadRawPathHashes("rawpathhashes.bin");
    WolvenEngine::SetWitcherExePath(exedir.c_str());

    std::string asset = "items\\work\\bottle_01\\bottle_open.w2mesh";

    std::vector<Mesh> meshes;
    std::vector<WolvenEngine::Material> materials;

    bool rc = WolvenEngine::loadMesh(asset, meshes, materials);
    EXPECT_TRUE(rc);
}

TEST(TestBundle, TestMeshLayer) {
    //EXPECT_EQ(1, 1);
    //EXPECT_TRUE(true);

    WolvenEngine::LoadRawPathHashes("rawpathhashes.bin");
    WolvenEngine::SetWitcherExePath(exedir.c_str());

    std::string asset = "levels\\island_of_mist\\island_of_mist.w2w";

    WolvenEngine::BundleEntry bundle;
    bool rc = WolvenEngine::GetFileInfo(asset, bundle);
    EXPECT_TRUE(rc);

    std::string bundlePath = WolvenEngine::GetBundlePath(bundle.index);

    WolvenEngine::Bundle archive;
    rc = archive.open(bundlePath.c_str());
    EXPECT_TRUE(rc);

    WolvenEngine::File fp;
    rc = archive.load(bundle.offset, bundle.compressedSize, bundle.uncompressedSize, bundle.compression, fp);
    EXPECT_TRUE(rc);

    // write out the file for comparison to the unbundled version
    FILE* out = nullptr;
    if (fopen_s(&out, "island_of_mist.w2w", "wb") == 0)
    {
        fwrite(fp.getBuffer<char*>(), fp.size(), 1, out);
        fclose(out);
    }
}