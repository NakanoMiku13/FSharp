open System
open System.IO
open Sum
[<EntryPoint>]
let main argv =
    if argv.Length = 1 then
        let filePath = argv[0]
        printfn "Processing %s" filePath
        if File.Exists(filePath) then
            try
                Summaries.summarize filePath
                0
            //Here we create an exception if something go wrong
            with
            | :? FormatException as e->
                printfn "Error: %s" e.Message
                printfn "Something go wrong"
                1
            | :? IO.IOException as e ->
                printfn "Error: %s" e.Message
                printfn "The file is not readable now"
                1
        else
            printfn "There is no file"
            2
    else
        printfn "Error, please try again"
        1