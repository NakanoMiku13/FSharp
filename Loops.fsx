
//Iterating on a function
let sayHello person =
    printfn "Hello %s" person

[<EntryPoint>]
let main argv =
    //Iterating on the elements and using a function
    printfn "1"
    for i in 0..argv.Length-1 do
        sayHello(argv[i])
    //Iterating on the elements of an array
    printfn "2"
    for i in argv do
        let person = i
        printfn "Hello %s" person
    //Iterating on the elements using a function called iter
    printfn "3"
    //Function action array
    Array.iter sayHello argv
    0