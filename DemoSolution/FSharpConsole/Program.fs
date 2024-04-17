let n = 455

let ms = new System.IO.MemoryStream()

[2;3;4;7;8] |> List.iter (fun x -> ms.WriteByte ((byte)x))

System.Diagnostics.Debugger.Break()

// debugger visualizer does NOT open for n or ms, the method CreateVisualizerAsync is not even called

printf "done"