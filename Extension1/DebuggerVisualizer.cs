namespace Extension1;

using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Extensibility;
using Microsoft.VisualStudio.Extensibility.DebuggerVisualizers;
using Microsoft.VisualStudio.RpcContracts.RemoteUI;

[VisualStudioContribution]
internal class IntVisualizerProvider : DebuggerVisualizerProvider
{
    /// <inheritdoc/>
    public override DebuggerVisualizerProviderConfiguration DebuggerVisualizerProviderConfiguration => new(
        visualizerDisplayName: "int visualizer",
        targetType: typeof(System.Int32))
    {
        //VisualizerObjectSourceType = new VisualizerObjectSourceType(typeof(MemoryStreamVisualizerObjectSource)),
        Style = VisualizerStyle.ToolWindow,
    };
    
    /// <inheritdoc/>
    public override Task<IRemoteUserControl> CreateVisualizerAsync(VisualizerTarget visualizerTarget, CancellationToken cancellationToken)
    {
        return Task.FromResult<IRemoteUserControl>(new IntVisualizerUserControl(visualizerTarget));
    }
}
