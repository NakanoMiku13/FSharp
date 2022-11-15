open System.IO
open Sum
//Here we adding a extra module to the Float datatype
//When we use type data, we can say that we are using classes or structs, like in C or C++
//were we create data types and names
[<EntryPoint>]
let main argv =
    if argv.Length = 1 then
        let filePath = argv[0]
        printfn "Processing %s" filePath
        if File.Exists(filePath) then
            Summaries.summarize filePath
            0
        else
            printfn "There is no file"
            2
    else
        printfn "Error, please try again"
        1