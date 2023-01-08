using Mafi;
using Mafi.Base;
using Mafi.Core.Buildings.Storages;
using Mafi.Core.Entities.Animations;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Mods;
using Mafi.Core.Products;
using System;
using static Mafi.Base.Assets.Core;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core.Ports.Io;
using Mafi.Core.Prototypes;

namespace SmallStorage;

internal class BuildingData : IModData
{
    private EntityLayout buildElevatorLayout(ProtosDb db, char port, char height)
    {
        IoPortShapeProto portShape = null;

        foreach (IoPortShapeProto item in db.All<IoPortShapeProto>())
        {
            if (item.LayoutChar == port)
            {
                portShape = item;
                break;
            }
        }

        if (portShape == null)
        {
            throw new InvalidOperationException("Invalid Port Shape char");
        }

        var layoutParams = new EntityLayoutParams(useNewLayoutSyntax: true);
        var initLayout = new EntityLayoutParser(db).ParseLayoutOrThrow(layoutParams, "[" + height + "]");
        var ports = new IoPortTemplate[]
        {
            new IoPortTemplate(new PortSpec('A', IoPortType.Any, portShape, false), RelTile3i.Zero, Direction90.PlusX),
            new IoPortTemplate(new PortSpec('Z', IoPortType.Any, portShape, false), new RelTile3i(RelTile2i.Zero, height - 49), Direction90.MinusX)
        };
        
        return new EntityLayout("", initLayout.LayoutTiles, initLayout.TerrainVertices, ports.ToImmutableArray(), layoutParams, initLayout.CollapseVerticesThreshold);
    }

	public void RegisterData(ProtoRegistrator registrator) {
        var zipperProtoBuilder = new ZipperProtoBuilder(registrator);

        zipperProtoBuilder.Start("Unit Elevator 1", ModIds.Storages.UnitElevator1)
			.Description("")
			.SetCost(Costs.Build.CP(1).Workers(0))
            .SetLayout(buildElevatorLayout(registrator.PrototypesDb, '#', '2'))
            .SetProductsFilter((proto) => proto is CountableProductProto)
			.SetCategories(Ids.ToolbarCategories.Transports)
			.SetPrefabPath("Assets/SmallStorage/unitele1.prefab")
			.BuildAndAdd();

        zipperProtoBuilder.Start("Unit Elevator 2", ModIds.Storages.UnitElevator2)
			.Description("")
			.SetCost(Costs.Build.CP(2).Workers(0))
            .SetLayout(buildElevatorLayout(registrator.PrototypesDb, '#', '3'))
            .SetProductsFilter((proto) => proto is CountableProductProto)
            .SetCategories(Ids.ToolbarCategories.Transports)
			.SetPrefabPath("Assets/SmallStorage/unitele2.prefab")
			.BuildAndAdd();

        zipperProtoBuilder.Start("Loose Elevator 1", ModIds.Storages.LooseElevator1)
			.Description("")
			.SetCost(Costs.Build.CP(1).Workers(0))
            .SetLayout(buildElevatorLayout(registrator.PrototypesDb, '~', '2'))
            .SetProductsFilter((proto) => proto is LooseProductProto)
            .SetCategories(Ids.ToolbarCategories.Transports)
			.SetPrefabPath("Assets/SmallStorage/looseele1.prefab")
			.BuildAndAdd();

        zipperProtoBuilder.Start("Loose Elevator 2", ModIds.Storages.LooseElevator2)
			.Description("")
			.SetCost(Costs.Build.CP(2).Workers(0))
            .SetLayout(buildElevatorLayout(registrator.PrototypesDb, '~', '3'))
            .SetProductsFilter((proto) => proto is LooseProductProto)
            .SetCategories(Ids.ToolbarCategories.Transports)
			.SetPrefabPath("Assets/SmallStorage/looseele2.prefab")
			.BuildAndAdd();

		registrator.StorageProtoBuilder.Start("Micro Unit Storage", ModIds.Storages.UnitMicro)
			.Description("")
            .SetCapacity(30)
            .SetNoTransferLimit()
			.SetCost(Costs.Build.CP(5).Workers(0))
			.SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
				"A#>[3]>#V")
            .SetProductsFilter((proto) => proto is CountableProductProto)
            .SetCategories(Ids.ToolbarCategories.Storages)
			.SetPrefabPath("Assets/SmallStorage/unitmicro.prefab")
			.BuildAndAdd();

        registrator.StorageProtoBuilder.Start("Mini Unit Storage", ModIds.Storages.UnitMini)
            .Description("")
            .SetCapacity(60)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(10).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A#>[3][3]>#V",
                "B#>[3][3]>#W")
            .SetProductsFilter((proto) => proto is CountableProductProto)
            .SetCategories(Ids.ToolbarCategories.Storages)
			.SetPrefabPath("Assets/SmallStorage/unitmini.prefab")
            .BuildAndAdd();

        registrator.StorageProtoBuilder.Start("Small Unit Storage", ModIds.Storages.UnitSmall)
            .Description("")
            .SetCapacity(90)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(10).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A#>[4][4][4]>#V",
                "   [4][4][4]   ",
                "B#>[4][4][4]>#W")
            .SetProductsFilter((proto) => proto is CountableProductProto)
            .SetCategories(Ids.ToolbarCategories.Storages)
			.SetPrefabPath("Assets/SmallStorage/unitsmall.prefab")
            .BuildAndAdd();

        registrator.StorageProtoBuilder.Start("Micro Loose Storage", ModIds.Storages.LooseMicro)
            .Description("")
            .SetCapacity(30)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(5).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A~>[3][3]>~V")
            .SetProductsFilter((proto) => proto is LooseProductProto)
            .SetCategories(Ids.ToolbarCategories.Storages)
			.SetPrefabPath("Assets/SmallStorage/loosemicro.prefab")
            .BuildAndAdd();

        registrator.StorageProtoBuilder.Start("Mini Loose Storage", ModIds.Storages.LooseMini)
            .Description("")
            .SetCapacity(60)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(10).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A~>[3][3]>~V",
                "B~>[3][3]>~W")
            .SetProductsFilter((proto) => proto is LooseProductProto)
            .SetCategories(Ids.ToolbarCategories.Storages)
			.SetPrefabPath("Assets/SmallStorage/loosemini.prefab")
            .BuildAndAdd();

        registrator.StorageProtoBuilder.Start("Small Loose Storage", ModIds.Storages.LooseSmall)
            .Description("")
            .SetCapacity(90)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(10).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A~>[4][4][4]>~V",
                "   [4][4][4]   ",
                "B~>[4][4][4]>~W")
            .SetProductsFilter((proto) => proto is LooseProductProto)
            .SetCategories(Ids.ToolbarCategories.Storages)
			.SetPrefabPath("Assets/SmallStorage/loosesmall.prefab")
            .BuildAndAdd();

        registrator.StorageProtoBuilder.Start("Micro Fluid Storage", ModIds.Storages.FluidMicro)
            .Description("")
            .SetCapacity(60)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(5).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A@>[3][3]>@V")
            .SetProductsFilter((proto) => proto is FluidProductProto)
            .SetCategories(Ids.ToolbarCategories.Storages)
			.SetPrefabPath("Assets/SmallStorage/fluidmicro.prefab")
            .BuildAndAdd();

        registrator.StorageProtoBuilder.Start("Mini Fluid Storage", ModIds.Storages.FluidMini)
            .Description("")
            .SetCapacity(120)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(10).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A@>[3][3]>@V",
                "B@>[3][3]>@W")
            .SetProductsFilter((proto) => proto is FluidProductProto)
            .SetCategories(Ids.ToolbarCategories.Storages)
			.SetPrefabPath("Assets/SmallStorage/fluidmini.prefab")
            .BuildAndAdd();

        registrator.StorageProtoBuilder.Start("Small Fluid Storage", ModIds.Storages.FluidSmall)
            .Description("")
            .SetCapacity(180)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(10).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A@>[4][4][4]>@V",
                "   [4][4][4]   ",
                "B@>[4][4][4]>@W")
            .SetProductsFilter((proto) => proto is FluidProductProto)
            .SetCategories(Ids.ToolbarCategories.Storages)
			.SetPrefabPath("Assets/SmallStorage/fluidsmall.prefab")
            .BuildAndAdd();

        //registrator.MachineProtoBuilder
        //    .Start("Example furnace", ExampleModIds.Machines.ExampleFurnace)
        //    .Description("Testing furnace")
        //    .SetCost(Costs.Build.CP(80).Workers(10))
        //    // For examples of layouts see `Mafi.Base.BaseMod` and `EntityLayoutParser`.
        //    .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
        //        "   [2][2][2][3][3][3][3][3][2]>~Y",
        //        "   [2][2][3][5][5][7][7][4][3]   ",
        //        "A~>[2][2][3][5][5][7][7][4][3]>'V",
        //        "B~>[2][2][3][5][5][7][7][4][3]>'W",
        //        "   [2][2][2][3][3][7][7][4][3]   ",
        //        "   [2][2][2][2][2][2][2][2][3]>@E")
        //    .SetCategories(Ids.ToolbarCategories.MachinesMetallurgy)
        //    .SetPrefabPath("Assets/ExampleMod/BlastFurnace.prefab")
        //    .SetAnimationParams(
        //        animParams: AnimationParams.RepeatTimes(Duration.FromKeyframes(360),
        //        times: 2,
        //        changeSpeedToFit: true))
        //    .BuildAndAdd();

        // Example of a new furnace recipe.
        //registrator.RecipeProtoBuilder
        //    .Start(name: "Example smelting",
        //        recipeId: ExampleModIds.Recipes.ExampleSmelting,
        //        machineId: ExampleModIds.Machines.ExampleFurnace)
        //    .AddInput(8, ExampleModIds.Products.ExampleLooseProduct)
        //    .AddInput(2, Ids.Products.Coal)
        //    .SetDuration(20.Seconds())
        //    .AddOutput(8, ExampleModIds.Products.ExampleMoltenProduct)
        //    .AddOutput(24, Ids.Products.Exhaust, outputAtStart: true)
        //    .BuildAndAdd();

    }
}