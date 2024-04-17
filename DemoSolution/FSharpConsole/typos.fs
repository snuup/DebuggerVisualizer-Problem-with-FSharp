module ModuleF

type AA() =
    member _.Name = "hase"

let k = new System.IO.MemoryStream()

let f() =
    let ms2 = new System.IO.MemoryStream()
    ms2