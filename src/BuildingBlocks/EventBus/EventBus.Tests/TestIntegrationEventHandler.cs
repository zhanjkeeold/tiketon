using System.Threading.Tasks;
using Tiketon.BuildingBlocks.EventBus.Abstractions;

namespace EventBus.Tests
{
    public class TestIntegrationEventHandler : IIntegrationEventHandler<TestIntegrationEvent>
    {
        public TestIntegrationEventHandler()
        {
            Handled = false;
        }

        public bool Handled { get; private set; }

        public async Task Handle(TestIntegrationEvent @event)
        {
            Handled = true;
        }
    }
}