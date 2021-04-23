// ConsoleTestHarness.cpp : This file contains the 'main' function. Program execution begins and ends there.
//

#include <iostream>
#include "wkengine.h"

int main()
{
    AddResourcePath("D:/Tools/ModTools/r4data/");

    //if (LoadAsset("D:/Tools/ModTools/r4data/levels/island_of_mist/island_of_mist.w2w"))
    //if (LoadAsset("D:/Tools/ModTools/r4data/levels/island_of_mist/island_of_mist/decorations_ns.w2l"))
    //if (LoadAsset("D:/Tools/ModTools/r4data/levels/kaer_morhen/kaer_morhen.w2w"))
    if (LoadAsset("D:/Tools/ModTools/r4data/characters/models/animals/bat/model/t_01__bat.w2mesh"))
    //if (LoadAsset("D:/Tools/ModTools/r4data/levels/novigrad/novigrad/triss_hideout/building_exterior.w2l"))
    //if (LoadAsset("D:/Tools/ModTools/r4data/levels/novigrad/bald_mountain/h2o_lakes/h2o_lakes.w2l"))
    //if (LoadAsset("D:/Tools/ModTools/r4data/levels/novigrad/baron_lair/baron_castle/baron_quartermaster/decorations_exterior_ns.w2l"))
    //if(LoadAsset("D:/Tools/ModTools/r4data/environment/decorations/near_water/fishing_nets/fishing_net_hanging_flat_short.w2mesh"))
    //if(LoadAsset("D:/Tools/ModTools/r4data/levels/skellige/an_skellig/sq210_impossible_tower/tower/tower.w2l"))
    //if (LoadAsset("D:/Tools/ModTools/r4data/levels/the_spiral/spiral.w2w"))
    //if(LoadAsset("D:/Tools/ModTools/r4data/environment/architecture/human/skellige/ard_skellig/kaer_trolde/buildings/broken_houses/broken_kaertro_house_storage_chimney_old.w2mesh"))
    //if (LoadAsset("D:/Tools/ModTools/r4data/levels/wyzima_castle/wyzima_castle.w2w"))

    //if (LoadAsset("D:/Tools/ModTools/r4data/levels/skellige/skellige.w2w"))
    //if (LoadAsset("D:/Tools/ModTools/r4data/levels/novigrad/novigrad.w2w"))

    //if(LoadAsset("D:/Downloads/vulkan-guide-all-chapters/assets/monkey_smooth.obj"))
    {
        WKRun(GetModuleHandle(NULL));
    }
}

// Run program: Ctrl + F5 or Debug > Start Without Debugging menu
// Debug program: F5 or Debug > Start Debugging menu

// Tips for Getting Started: 
//   1. Use the Solution Explorer window to add/manage files
//   2. Use the Team Explorer window to connect to source control
//   3. Use the Output window to see build output and other messages
//   4. Use the Error List window to view errors
//   5. Go to Project > Add New Item to create new code files, or Project > Add Existing Item to add existing code files to the project
//   6. In the future, to open this project again, go to File > Open > Project and select the .sln file
