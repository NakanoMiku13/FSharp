
let sayHello person =
    printfn "Hello to %s" person
let isValid person =
    //Using extention "fsx" it exist the error
    //But using "fs" extention it did not exist
    person <> " "
let isAllowed person =
    person <> "Soria"
[<EntryPoint>]
let main argv =
    //Common way
    printfn "Before filter"
    Array.iter sayHello argv
    printfn "After filter"
    //Using pipes, this works, giving the argument at the last moment, and it is useful to make filters or any other thing
    let validNames = argv |> Array.filter isValid
    validNames  |> Array.iter sayHello

    //Using pipes like pro
    printfn "This is like a pro do it with pipes"
    argv
    |> Array.filter isValid
    |> Array.filter isAllowed
    |> Array.iter sayHello
    0