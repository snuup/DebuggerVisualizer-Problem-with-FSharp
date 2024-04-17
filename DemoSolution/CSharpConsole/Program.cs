
//var n = 123;
var ms = new MemoryStream();
ms.Write([10, 2, 3, 4, 5, 100, 1]);

var a = new ModuleF.AA();

// Console.WriteLine(a.Name);

ms = ModuleF.f();

System.Diagnostics.Debugger.Break();

// debugger visualizer opens for n (yet it fails because the control is not seriously implemented)
