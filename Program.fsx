[<EntryPoint>]
let main argv =
    let person =
        if argv.Length > 0 then
            argv[0]
        else
            "Anon"
    printfn "Hello world %s" person
    0