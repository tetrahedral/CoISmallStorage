

using Mafi;
using Mafi.Core.Entities.Static;
using Mafi.Core.Entities.Static.Layout;
using Mafi.Core.Factory.Zippers;
using Mafi.Core.Mods;
using Mafi.Core.Products;
using Mafi.Core.Prototypes;

namespace SmallStorage;

public sealed class ZipperProtoBuilder : IProtoBuilder
{
    public class State : LayoutEntityBuilderState<State>
    {
        private readonly StaticEntityProto.ID m_protoId;

        private EntityLayout m_entityLayout;

        private Electricity m_requiredPower;

        public State(ZipperProtoBuilder builder, StaticEntityProto.ID protoId, string name)
            : base(builder, protoId, name)
        {
            m_protoId = protoId;
        }

        public State SetLayout(EntityLayout layout)
        {
            m_entityLayout = layout;
            return this;
        }

        public State SetRequiredPower(Electricity electricity)
        {
            m_requiredPower = electricity;
            return this;
        }

        public ZipperProto BuildAndAdd(ProductType? productType = null)
        {
            return AddToDb(new ZipperProto(m_protoId, base.Strings, m_entityLayout == null ? base.LayoutOrThrow : m_entityLayout, base.Costs, m_requiredPower, base.Graphics));
        }
    }

    public ProtosDb ProtosDb => Registrator.PrototypesDb;

    public ProtoRegistrator Registrator { get; }

    public ZipperProtoBuilder(ProtoRegistrator registrator)
    {
        Registrator = registrator;
    }

    public State Start(string name, StaticEntityProto.ID id)
    {
        return new State(this, id, name);
    }
}