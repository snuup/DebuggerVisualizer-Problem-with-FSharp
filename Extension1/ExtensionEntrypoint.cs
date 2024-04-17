namespace Extension1;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.Extensibility;

/// <summary>
/// Extension entrypoint for the VisualStudio.Extensibility extension.
/// </summary>
[VisualStudioContribution]
internal class ExtensionEntrypoint : Extension
{
    /// <inheritdoc/>
    public override ExtensionConfiguration ExtensionConfiguration => new()
    {
        Metadata = new(
                id: "Extension1.09c0d942-c37b-467e-9fd3-055b6d80b295",
                version: this.ExtensionAssemblyVersion,
                publisherName: "Publisher name",
                displayName: "Extension1",
                description: "Extension description"),
    };

    /// <inheritdoc />
    protected override void InitializeServices (IServiceCollection serviceCollection)
    {
        base.InitializeServices(serviceCollection);

        // You can configure dependency injection here by adding services to the serviceCollection.
    }
}
