namespace Extension1;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.DebuggerVisualizers;
using Microsoft.VisualStudio.RpcContracts.RemoteUI;

[VisualStudioContribution]
internal class StringVisualizerProvider : DebuggerVisualizerProvider
{
    /// <inheritdoc/>
    public override DebuggerVisualizerProviderConfiguration DebuggerVisualizerProviderConfiguration => new(
        visualizerDisplayName: "striny visualizer 1704",
        targetType: typeof(String))
    {
        //VisualizerObjectSourceType = new VisualizerObjectSourceType(typeof(MemoryStreamVisualizerObjectSource)),
        Style = VisualizerStyle.ToolWindow,
    };
    
    /// <inheritdoc/>
    public override Task<IRemoteUserControl> CreateVisualizerAsync(VisualizerTarget visualizerTarget, CancellationToken cancellationToken)
    {
        return Task.FromResult<IRemoteUserControl>(new StringVisualizerUserControl(visualizerTarget));
    }
}
