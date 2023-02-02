using Mafi;
using Mafi.Base;
using Mafi.Core.Mods;
using Mafi.Core.Research;

namespace SmallStorage;

internal class ResearchData : IResearchNodesData {

    public void RegisterData(ProtoRegistrator registrator) {

        ResearchNodeProto nodeProto = registrator.ResearchNodeProtoBuilder
            .Start("Small Storage Buildings", ModIds.Research.UnlockSmallStorage)
            .Description("Unlocks 1x2, 2x2, and 3x3 storage buildings.")
            .SetCosts(new ResearchCostsTpl(1))
            .AddLayoutEntityToUnlock(ModIds.Storages.UnitMicro)
            .AddLayoutEntityToUnlock(ModIds.Storages.UnitMini)
            .AddLayoutEntityToUnlock(ModIds.Storages.UnitSmall)
            .AddLayoutEntityToUnlock(ModIds.Storages.LooseMicro)
            .AddLayoutEntityToUnlock(ModIds.Storages.LooseMini)
            .AddLayoutEntityToUnlock(ModIds.Storages.LooseSmall)
            .AddLayoutEntityToUnlock(ModIds.Storages.FluidMicro)
            .AddLayoutEntityToUnlock(ModIds.Storages.FluidMini)
            .AddLayoutEntityToUnlock(ModIds.Storages.FluidSmall)
            .AddLayoutEntityToUnlock(ModIds.Storages.UnitElevator1)
            .AddLayoutEntityToUnlock(ModIds.Storages.UnitElevator2)
            .AddLayoutEntityToUnlock(ModIds.Storages.LooseElevator1)
            .AddLayoutEntityToUnlock(ModIds.Storages.LooseElevator2)
            .BuildAndAdd();

        nodeProto.GridPosition = new Vector2i(16, 31);
        nodeProto.AddParent(registrator.PrototypesDb.GetOrThrow<ResearchNodeProto>(Ids.Research.StoragesT1));
    }

}