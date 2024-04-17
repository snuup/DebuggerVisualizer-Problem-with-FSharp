
var s1 = "s1 from c#";
var s2 = "s2 from c#";

var s3 = ModuleF.f();

var s4 = CS.f();

System.Diagnostics.Debugger.Break();

class CS
{
    public static string f ()
    {
        var s1 = "bugs";
        var s2 = s1 + " bunny";
        return s2;
    }
}