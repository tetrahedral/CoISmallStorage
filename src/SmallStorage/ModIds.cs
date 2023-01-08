using Mafi.Base;
using Mafi.Core.Entities.Static;
// using MachineID = Mafi.Core.Factory.Machines.MachineProto.ID;
// using ProductID = Mafi.Core.Products.ProductProto.ID;
// using RecipeID = Mafi.Core.Factory.Recipes.RecipeProto.ID;
using ResNodeID = Mafi.Core.Research.ResearchNodeProto.ID;

namespace SmallStorage;

public partial class ModIds
{
	public partial class Machines
    {
		// public static readonly MachineID ExampleFurnace = Ids.Machines.CreateId("ExampleFurnace");
	}

	// Products proto registrations can be done either by manually constructing and registering
	// `ProductProto` variants or by defining IDs and marking them with one of following attributes:
	// CountableProduct, FluidProduct, LooseProduct, MoltenProduct, or VirtualProduct.
	// These static IDs are then automatically registered via `registrator.RegisterAllProducts()`.
	public static partial class Products
    {
		// [CountableProduct(icon: Assets.Base.Products.Icons.Wood_svg,
		// 	prefab: Assets.Base.Products.Countable.RawWood_prefab)]
		// public static readonly ProductID ExampleUnitProduct = Ids.Products.CreateId("ExampleUnitProduct");

		// [FluidProduct(color: 0xFF00FF, icon: Assets.Base.Products.Icons.Water_svg)]
		// public static readonly ProductID ExampleFluidProduct = Ids.Products.CreateId("ExampleFluidProduct");

		// [LooseProduct(material: Assets.Base.Products.Loose.Dirt_mat,
		// 	icon: Assets.Base.Products.Icons.Dirt_svg, dumpByDefault: true, isFarmable: true)]
		// public static readonly ProductID ExampleLooseProduct = Ids.Products.CreateId("ExampleLooseProduct");

		// [MoltenProduct(material: Assets.Base.Products.Molten.Copper_mat,
		// 	prefab: Assets.Base.Products.Molten.MoltenCopper_prefab,
		// 	icon: Assets.Base.Products.Icons.CopperMolten_svg)]
		// public static readonly ProductID ExampleMoltenProduct = Ids.Products.CreateId("ExampleMoltenProduct");
	}

	public partial class Recipes
    {
		// public static readonly RecipeID ExampleSmelting = Ids.Recipes.CreateId("ExampleSmelting");
	}

	public partial class Research
    {
		public static readonly ResNodeID UnlockSmallStorage = Ids.Research.CreateId("SmallStorage_Unlock");
	}

    public partial class Storages
    {
        public static readonly StaticEntityProto.ID UnitElevator1 = new StaticEntityProto.ID("SmallStorage_UnitElevator1");
        public static readonly StaticEntityProto.ID UnitElevator2 = new StaticEntityProto.ID("SmallStorage_UnitElevator2");
        
        public static readonly StaticEntityProto.ID LooseElevator1 = new StaticEntityProto.ID("SmallStorage_LooseElevator1");
        public static readonly StaticEntityProto.ID LooseElevator2 = new StaticEntityProto.ID("SmallStorage_LooseElevator2");

        public static readonly StaticEntityProto.ID UnitMicro = new StaticEntityProto.ID("SmallStorage_StorageUnitMicro");
        public static readonly StaticEntityProto.ID UnitMini = new StaticEntityProto.ID("SmallStorage_StorageUnitMini");
        public static readonly StaticEntityProto.ID UnitSmall = new StaticEntityProto.ID("SmallStorage_StorageUnitSmall");

        public static readonly StaticEntityProto.ID LooseMicro = new StaticEntityProto.ID("SmallStorage_StorageLooseMicro");
        public static readonly StaticEntityProto.ID LooseMini = new StaticEntityProto.ID("SmallStorage_StorageLooseMini");
        public static readonly StaticEntityProto.ID LooseSmall = new StaticEntityProto.ID("SmallStorage_StorageLooseSmall");
        
        public static readonly StaticEntityProto.ID FluidMicro = new StaticEntityProto.ID("SmallStorage_StorageFluidMicro");
        public static readonly StaticEntityProto.ID FluidMini = new StaticEntityProto.ID("SmallStorage_StorageFluidMini");
        public static readonly StaticEntityProto.ID FluidSmall = new StaticEntityProto.ID("SmallStorage_StorageFluidSmall");
    }
}