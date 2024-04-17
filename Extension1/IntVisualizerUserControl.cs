// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Extension1;

using System;
using System.Buffers;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.VisualStudio.Extensibility.DebuggerVisualizers;
using Microsoft.VisualStudio.Extensibility.UI;
using Microsoft.VisualStudio.RpcContracts.DebuggerVisualizers;
using Newtonsoft.Json.Linq;

class IntContext : NotifyPropertyChangedObject
{
    string _value;

    public string IntValue
    {
        set
        {
            this._value = value;
            this.RaiseNotifyPropertyChangedEvent("IntValue");
        }
        get
        {
            return this._value;
        }
    }
}

/// <summary>
/// Remote UI user control for the MemoryStreamVisualizer.
/// </summary>
internal class IntVisualizerUserControl : RemoteUserControl
{
    private readonly VisualizerTarget visualizerTarget;
    private readonly IntContext dataContext;

    public IntVisualizerUserControl (VisualizerTarget visualizerTarget) : base(new IntContext())
    {
        visualizerTarget.StateChanged += this.VisualizerTargetStateChangedAsync;
        this.dataContext = (IntContext) this.DataContext!;
        this.visualizerTarget = visualizerTarget;
    }

    private async Task VisualizerTargetStateChangedAsync (object? sender, VisualizerTargetStateNotification args)
    {
        if (args == VisualizerTargetStateNotification.Available || args == VisualizerTargetStateNotification.ValueUpdated)
        {
            JToken jtoken = await this.visualizerTarget.ObjectSource.RequestDataAsync(CancellationToken.None);
            this.dataContext.IntValue = ((JValue) jtoken).Value.ToString();
        }
    }
}
