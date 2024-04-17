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

[DataContract]
class StringContext : NotifyPropertyChangedObject
{
    string value = "initial value"; // debug purpose

    [DataMember]
    public string Value
    {
        set
        {
            if (this.SetProperty(ref this.value, value))
            {
                this.RaiseNotifyPropertyChangedEvent();
            }
        }
        get => this.value;
    }
}

/// <summary>
/// Remote UI user control for the IntVisualizer.
/// </summary>
class StringVisualizerUserControl : RemoteUserControl
{
    readonly VisualizerTarget visualizerTarget;
    readonly StringContext dataContext;

    public StringVisualizerUserControl (VisualizerTarget visualizerTarget) : base(new StringContext())
    {
        visualizerTarget.StateChanged += this.VisualizerTargetStateChangedAsync;
        this.dataContext = (StringContext) this.DataContext!;
        this.visualizerTarget = visualizerTarget;
    }

    async Task VisualizerTargetStateChangedAsync (object? sender, VisualizerTargetStateNotification args)
    {
        if (args == VisualizerTargetStateNotification.Available || args == VisualizerTargetStateNotification.ValueUpdated)
        {
            JToken jtoken = await this.visualizerTarget.ObjectSource.RequestDataAsync(CancellationToken.None);
            this.dataContext.Value = ((JValue) jtoken).Value.ToString();
        }
    }

    
}
