//Curried parameters
//Is a function parameters wich support partial application
//When an argument is supplied, the result is a function that expects any remaining parameters.
//When all arguments have been supplied, the function returns a result
let add a b = a + b
let c = add 2 3
//Partial application of a function
//Here d is expecting the new argument (b)
let d = add 2
let e = d 4
[<EntryPoint>]
let main argv =
    0