using Mafi;
using Mafi.Base;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Mods;
using Mafi.Core.Products;
using System;
using System.Linq;
using Mafi.Collections.ImmutableCollections;
using Mafi.Core.Ports.Io;
using Mafi.Core.Prototypes;

namespace SmallStorage;

internal class BuildingData : IModData
{
    public void RegisterData(ProtoRegistrator registrator)
    {
        var unitProductType = new ProductType(typeof(CountableProductProto));
        var looseProductType = new ProductType(typeof(LooseProductProto));
        var fluidProductType = new ProductType(typeof(FluidProductProto));
        
        var zipperProtoBuilder = new ZipperProtoBuilder(registrator);

        zipperProtoBuilder.Start("Unit Elevator 1", ModIds.Storages.UnitElevator1)
            .Description("")
            .SetCost(Costs.Build.CP(1).Workers(0))
            .SetLayout(BuildElevatorLayout(registrator.PrototypesDb, '#', '2'))
            .SetCategories(Ids.ToolbarCategories.Transports)
            .SetPrefabPath("Assets/SmallStorage/unitele1.prefab")
            .BuildAndAdd();

        zipperProtoBuilder.Start("Unit Elevator 2", ModIds.Storages.UnitElevator2)
            .Description("")
            .SetCost(Costs.Build.CP(2).Workers(0))
            .SetLayout(BuildElevatorLayout(registrator.PrototypesDb, '#', '3'))
            .SetCategories(Ids.ToolbarCategories.Transports)
            .SetPrefabPath("Assets/SmallStorage/unitele2.prefab")
            .BuildAndAdd();

        zipperProtoBuilder.Start("Loose Elevator 1", ModIds.Storages.LooseElevator1)
            .Description("")
            .SetCost(Costs.Build.CP(1).Workers(0))
            .SetLayout(BuildElevatorLayout(registrator.PrototypesDb, '~', '2'))
            .SetCategories(Ids.ToolbarCategories.Transports)
            .SetPrefabPath("Assets/SmallStorage/looseele1.prefab")
            .BuildAndAdd();

        zipperProtoBuilder.Start("Loose Elevator 2", ModIds.Storages.LooseElevator2)
            .Description("")
            .SetCost(Costs.Build.CP(2).Workers(0))
            .SetLayout(BuildElevatorLayout(registrator.PrototypesDb, '~', '3'))
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
            .SetCategories(Ids.ToolbarCategories.Storages)
            .SetPrefabPath("Assets/SmallStorage/unitmicro.prefab")
            .BuildAndAdd(unitProductType);

        registrator.StorageProtoBuilder.Start("Mini Unit Storage", ModIds.Storages.UnitMini)
            .Description("")
            .SetCapacity(60)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(10).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A#>[3][3]>#V",
                "B#>[3][3]>#W")
            .SetCategories(Ids.ToolbarCategories.Storages)
            .SetPrefabPath("Assets/SmallStorage/unitmini.prefab")
            .BuildAndAdd(unitProductType);

        registrator.StorageProtoBuilder.Start("Small Unit Storage", ModIds.Storages.UnitSmall)
            .Description("")
            .SetCapacity(90)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(10).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A#>[4][4][4]>#V",
                "   [4][4][4]   ",
                "B#>[4][4][4]>#W")
            .SetCategories(Ids.ToolbarCategories.Storages)
            .SetPrefabPath("Assets/SmallStorage/unitsmall.prefab")
            .BuildAndAdd(unitProductType);

        registrator.StorageProtoBuilder.Start("Micro Loose Storage", ModIds.Storages.LooseMicro)
            .Description("")
            .SetCapacity(30)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(5).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A~>[3][3]>~V")
            .SetCategories(Ids.ToolbarCategories.Storages)
            .SetPrefabPath("Assets/SmallStorage/loosemicro.prefab")
            .BuildAndAdd(looseProductType);

        registrator.StorageProtoBuilder.Start("Mini Loose Storage", ModIds.Storages.LooseMini)
            .Description("")
            .SetCapacity(60)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(10).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A~>[3][3]>~V",
                "B~>[3][3]>~W")
            .SetCategories(Ids.ToolbarCategories.Storages)
            .SetPrefabPath("Assets/SmallStorage/loosemini.prefab")
            .BuildAndAdd(looseProductType);

        registrator.StorageProtoBuilder.Start("Small Loose Storage", ModIds.Storages.LooseSmall)
            .Description("")
            .SetCapacity(90)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(10).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A~>[4][4][4]>~V",
                "   [4][4][4]   ",
                "B~>[4][4][4]>~W")
            .SetCategories(Ids.ToolbarCategories.Storages)
            .SetPrefabPath("Assets/SmallStorage/loosesmall.prefab")
            .BuildAndAdd(looseProductType);

        registrator.StorageProtoBuilder.Start("Micro Fluid Storage", ModIds.Storages.FluidMicro)
            .Description("")
            .SetCapacity(60)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(5).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A@>[3][3]>@V")
            .SetCategories(Ids.ToolbarCategories.Storages)
            .SetPrefabPath("Assets/SmallStorage/fluidmicro.prefab")
            .BuildAndAdd(fluidProductType);

        registrator.StorageProtoBuilder.Start("Mini Fluid Storage", ModIds.Storages.FluidMini)
            .Description("")
            .SetCapacity(120)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(10).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A@>[3][3]>@V",
                "B@>[3][3]>@W")
            .SetCategories(Ids.ToolbarCategories.Storages)
            .SetPrefabPath("Assets/SmallStorage/fluidmini.prefab")
            .BuildAndAdd(fluidProductType);

        registrator.StorageProtoBuilder.Start("Small Fluid Storage", ModIds.Storages.FluidSmall)
            .Description("")
            .SetCapacity(180)
            .SetNoTransferLimit()
            .SetCost(Costs.Build.CP(10).Workers(0))
            .SetLayout(new EntityLayoutParams(useNewLayoutSyntax: true),
                "A@>[4][4][4]>@V",
                "   [4][4][4]   ",
                "B@>[4][4][4]>@W")
            .SetCategories(Ids.ToolbarCategories.Storages)
            .SetPrefabPath("Assets/SmallStorage/fluidsmall.prefab")
            .BuildAndAdd(fluidProductType);
    }

    private static EntityLayout BuildElevatorLayout(ProtosDb db, char port, char height)
    {
        var portShape = db.All<IoPortShapeProto>().FirstOrDefault(p => p.LayoutChar == port);

        if (portShape == null)
        {
            throw new InvalidOperationException("Invalid Port Shape char");
        }

        var layoutParams = new EntityLayoutParams(useNewLayoutSyntax: true);
        var initLayout = new EntityLayoutParser(db).ParseLayoutOrThrow(layoutParams, "[" + height + "]");
        var ports = new IoPortTemplate[]
        {
            new (new PortSpec('A', IoPortType.Any, portShape, false), RelTile3i.Zero, Direction90.PlusX),
            new (new PortSpec('Z', IoPortType.Any, portShape, false), new RelTile3i(RelTile2i.Zero, height - 49), Direction90.MinusX)
        };
        
        return new EntityLayout("", initLayout.LayoutTiles, initLayout.TerrainVertices, ports.ToImmutableArray(), layoutParams, initLayout.CollapseVerticesThreshold);
    }
}