using System.Threading.Tasks;
using Tiketon.BuildingBlocks.EventBus.Abstractions;

namespace EventBus.Tests
{
    public class TestIntegrationOtherEventHandler : IIntegrationEventHandler<TestIntegrationEvent>
    {
        public TestIntegrationOtherEventHandler()
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