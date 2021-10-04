

using Clv.Core.EFContext;

namespace Clv.Core.Factory
{
    public interface IContextFactory
    {
        IDatabaseContext DbContext { get; }
    }
}